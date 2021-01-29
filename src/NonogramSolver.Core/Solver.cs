using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core
{
    public class Solver : ISolver
    {
        public Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers)
        {
            var puzzle = new Puzzle(rows, columns, horizontalNumbers, verticalNumbers);
            FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);
            FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);
            // FillEdgeNumbers(puzzle, true, puzzle.Rows);
            // FillEdgeNumbers(puzzle, false, puzzle.Columns);

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

                var startIndex = 0;

                for (var i = 0; i < column.Numbers.Count; i++)
                {
                    FillNumber(column, column.Numbers[i], startIndex);
                    startIndex = column.Numbers[i].Number + i + 1;
                }
            }
        }

        private static void FillEdgeNumbers(Puzzle puzzle, bool isRow, int linesCount)
        {
            for (var index = 0; index < linesCount; index++)
            {
                var line = puzzle.GetLine(index, isRow);

                if (line.IsResolved())
                {
                    continue;
                }

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