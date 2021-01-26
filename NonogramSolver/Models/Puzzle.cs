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

        public Puzzle(int rows, int columns, List<List<LineNumber>> horizontalNumbers, List<List<LineNumber>> verticalNumbers)
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

        public Line GetColumnLine(int column)
        {
            var result = Desk.Select(x => x[column]).ToList();

            var line = new Line
            {
                Cells = result,
                Numbers = VerticalNumbers[column]
            };

            return line;
        }
        
        public Line GetRowLine(int row)
        {
            var line = new Line
            {
                Cells = Desk[row].ToList(),
                Numbers = HorizontalNumbers[row]
            };

            return line;
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write("{0,3}", Desk[i][j]);
                }
                
                Console.WriteLine();
            }
        }
    }
}