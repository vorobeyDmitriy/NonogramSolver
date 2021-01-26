using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Models;

namespace NonogramSolver
{
    public class Solver
    {
        public Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers, List<List<LineNumber>> verticalNumbers)
        {
            var puzzle = new Puzzle(rows, columns, horizontalNumbers, verticalNumbers);
            FillTrivialLines(puzzle);

            return puzzle;
        }

        public void FillTrivialLines(Puzzle puzzle)
        {
            for (var columnIndex = 0; columnIndex < puzzle.Columns; columnIndex++)
            {
                var column = puzzle.GetColumnLine(columnIndex);

                if (column.GetLengthWithSpaces() != puzzle.Rows)
                {
                    continue;
                }

                FillLine(column);

            }
            
            for (var rowIndex = 0; rowIndex < puzzle.Rows; rowIndex++)
            {
                var row = puzzle.GetRowLine(rowIndex);

                if (row.GetLengthWithSpaces() != puzzle.Columns)
                {
                    continue;
                }

                FillLine(row);
            }
        }

        public void FillLine(Line line)
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
                var startIndex = line.Numbers.Take(i).Sum(x=>x.Number) + i; 
                FillNumber(line, line.Numbers[i], startIndex);
            }
            
            line.Resolve();
        }

        public void FillNumber(Line line, LineNumber number, int startIndex)
        {
            for (var i = startIndex; i < startIndex+number.Number; i++)
            {
                line.Cells[i].Fill();
            }

            var lastCrossIndex = startIndex + number.Number;
            
            if(lastCrossIndex < line.Cells.Count)
            {
                line.Cells[lastCrossIndex].Cross();
            }
            
            number.Resolve();
        }
    }
}