using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core
{
    public class Solver
    {
        public static Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers)
        {
            var puzzle = new Puzzle(rows, columns, horizontalNumbers, verticalNumbers);
            FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);
            FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);
            FillEdgeNumbers(puzzle, true, puzzle.Rows);
            FillEdgeNumbers(puzzle, false, puzzle.Columns);

            return puzzle;
        }

        private static void FillTrivialLines(Puzzle puzzle, bool isRow, int linesCount, int maxLineNumbersLength)
        {
            for (var columnIndex = 0; columnIndex < linesCount; columnIndex++)
            {
                var column = puzzle.GetLine(columnIndex, isRow);

                if (column.GetLengthWithSpaces() != maxLineNumbersLength)
                {
                    continue;
                }

                FillLine(column);
            }
        }

        private static void FillEdgeNumbers(Puzzle puzzle, bool isRow, int linesCount)
        {
            for (var index = 0; index < linesCount; index++)
            {
                var line = puzzle.GetLine(index, isRow);

                var firstNumber = line.Numbers.FirstOrDefault();
                var lastNumber = line.Numbers.LastOrDefault();

                if (firstNumber != null && !firstNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line, firstNumber);
                }

                if (lastNumber != null && !lastNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line, lastNumber);
                }
            }
        }

        private static void FillLine(Line line)
        {
            if (line.Numbers.Count == 1)
            {
                foreach (var cell in line.Cells)
                {
                    cell.Fill();
                }
            }

            for (var i = 0; i < line.Numbers.Count; i++)
            {
                var startIndex = line.Numbers.Take(i).Sum(x => x.Number) + i;
                FillNumber(line, line.Numbers[i], startIndex);
            }

            line.Resolve();
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

        private static void CheckAndFillEdgeNumbers(Line line, LineNumber edgeNumber)
        {
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
        }
    }
}