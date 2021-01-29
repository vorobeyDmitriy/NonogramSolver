using System;
using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Models
{
    public class Puzzle
    {
        public List<List<LineNumber>> VerticalNumbers { get; set; }
        public List<List<LineNumber>> HorizontalNumbers { get; set; }
        public Cell[][] Desk { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }

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

        public Line GetLine(int order, bool isRow)
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
    }
}