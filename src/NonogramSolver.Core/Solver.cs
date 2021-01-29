using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core
{
    public class Solver : ISolver
    {
        private const int MaxIterations = 1000;

        public Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers)
        {
            var puzzle = new Puzzle(rows, columns, horizontalNumbers, verticalNumbers);
            puzzle = Solve(puzzle);

            return puzzle;
        }

        public Puzzle Solve(Puzzle puzzle)
        {
            FillTrivialLines(puzzle);
            var maxIterations = MaxIterations;

            while (!puzzle.IsResolved() && maxIterations > 0)
            {
                FillEdgeNumbers(puzzle);
                FillCrossedNumbers(puzzle);
                CheckLinesForResolving(puzzle);
                maxIterations--;
            }

            return puzzle;
        }

        public void CheckLinesForResolving(Puzzle puzzle)
        {
            var lines = puzzle.GetLines().Where(x => !x.IsResolved());

            foreach (var line in lines)
            {
                var filledCellsCount = line.Cells.Count(x => x.Status == CellStatus.Filled);
                var sumOfNumbers = line.Numbers.Sum(x => x.Number);

                if (sumOfNumbers != filledCellsCount)
                {
                    continue;
                }

                foreach (var cell in line.Cells)
                {
                    cell.Cross();
                }

                foreach (var number in line.Numbers)
                {
                    number.Resolve();
                }
            }
        }
        
        public void FillTrivialLines(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                var maxLineNumbersLength = line.IsRow ? puzzle.Columns : puzzle.Rows;
                if (line.GetLengthWithSpaces() != maxLineNumbersLength)
                {
                    continue;
                }

                var startIndex = 0;

                for (var i = 0; i < line.Numbers.Count; i++)
                {
                    FillNumber(line, line.Numbers[i], startIndex);
                    startIndex = line.Numbers.Take(i + 1).Sum(x => x.Number) + i + 1;
                } 
            }
            
        }

        public void FillEdgeNumbers(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                if (line.IsResolved())
                {
                    continue;
                }

                var firstNumber = line.Numbers.FirstOrDefault();
                var lastNumber = line.Numbers.LastOrDefault();

                if (firstNumber != null && !firstNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line, firstNumber, false);

                    continue;
                }

                if (lastNumber != null && !lastNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line, lastNumber, true);
                }
            }
        }

        public void FillCrossedNumbers(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                if (line.IsResolved())
                {
                    continue;
                }

                var numbersCount = line.Numbers.Count;

                for (var i = 0; i < numbersCount; i++)
                {
                    var leftPosition = line.Numbers.Take(i + 1).Sum(x => x.Number) + i -1;

                    line.Numbers.Reverse();

                    var occupiedSpaceFromRight =
                        line.Numbers.Take(numbersCount - i).Sum(x => x.Number) + numbersCount - 2 - i;

                    line.Numbers.Reverse();

                    var rightPosition = line.Cells.Count - 1 - occupiedSpaceFromRight;

                    if (rightPosition > leftPosition)
                    {
                        continue;
                    }

                    for (var j = rightPosition; j <= leftPosition; j++)
                    {
                        line.Cells[j].Fill();
                    }
                }
            }
        }

        private static void FillNumber(Line line, LineNumber number, int startIndex)
        {
            for (var i = startIndex; i < startIndex + number.Number; i++)
            {
                line.Cells[i].Fill();
            }

            var lastCrossIndex = startIndex + number.Number;

            if (lastCrossIndex < line.Cells.Count)
            {
                line.Cells[lastCrossIndex].Cross();
            }

            number.Resolve(startIndex, startIndex + number.Number - 1);
        }

        private static void CheckAndFillEdgeNumbers(Line line, LineNumber edgeNumber, bool fromTheEnd)
        {
            if (fromTheEnd)
            {
                line.Cells.Reverse();
            }

            for (var i = 0; i < line.Cells.Count - 1; i++)
            {
                if (line.Cells[i].Status == CellStatus.Empty)
                {
                    break;
                }

                if (line.Cells[i].Status == CellStatus.Crossed)
                {
                    continue;
                }

                FillNumber(line, edgeNumber, i);

                break;
            }

            if (fromTheEnd)
            {
                line.Cells.Reverse();
            }
        }
    }
}