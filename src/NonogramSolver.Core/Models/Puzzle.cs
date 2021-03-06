﻿using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class Puzzle
    {
        public Puzzle(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers)
        {
            VerticalNumbers = verticalNumbers;
            HorizontalNumbers = horizontalNumbers;
            Columns = columns;
            Rows = rows;
            Desk = new Cell[rows][];

            for (var i = 0; i < rows; i++)
            {
                Desk[i] = new Cell[columns];
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Desk[i][j] = new Cell();
                }
            }
        }

        public List<List<LineNumber>> VerticalNumbers { get; }
        public List<List<LineNumber>> HorizontalNumbers { get; }
        public Cell[][] Desk { get; }
        public int Columns { get; }
        public int Rows { get; }

        private Line GetLine(int order, bool isRow)
        {
            Line line;

            if (isRow)
            {
                line = new Line
                {
                    Cells = Desk[order].ToList(),
                    Numbers = HorizontalNumbers[order]
                };

                return line;
            }

            var result = Desk.Select(x => x[order]).ToList();

            line = new Line
            {
                Cells = result,
                Numbers = VerticalNumbers[order]
            };

            return line;
        }

        public IEnumerable<Line> GetLines()
        {
            var result = new List<Line>();

            for (var i = 0; i < Rows; i++)
            {
                result.Add(GetLine(i, true));
            }

            for (var i = 0; i < Columns; i++)
            {
                result.Add(GetLine(i, false));
            }

            return result;
        }

        public bool IsResolved()
        {
            for (var columnIndex = 0; columnIndex < Columns; columnIndex++)
            {
                var line = GetLine(columnIndex, false);

                if (!line.IsResolved())
                {
                    return false;
                }
            }

            for (var rowIndex = 0; rowIndex < Rows; rowIndex++)
            {
                var line = GetLine(rowIndex, true);

                if (!line.IsResolved())
                {
                    return false;
                }
            }

            return true;
        }
    }
}