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
            var additionalRows = VerticalNumbers.Select(x => x.Count).Max();
            var additionalColumns = HorizontalNumbers.Select(x => x.Count).Max();

            foreach (var number in VerticalNumbers)
            {
                number.Reverse();
            }

            foreach (var number in HorizontalNumbers)
            {
                number.Reverse();
            }

            for (var i = 0; i < additionalRows; i++)
            {
                for (var j = 0; j < Columns + additionalColumns; j++)
                {
                    if (j < additionalColumns)
                    {
                        Console.Write("{0,3}", string.Empty);
                    }
                    else
                    {
                        var number = VerticalNumbers[j - additionalColumns]
                                     .ElementAtOrDefault(additionalRows - i - 1)
                                     ?.Number;

                        Console.Write("{0,3}", number?.ToString() ?? string.Empty);
                    }
                }

                Console.WriteLine();
            }

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns+additionalColumns; j++)
                {
                    if (j < additionalColumns)
                    {
                        var number = HorizontalNumbers[i].ElementAtOrDefault(additionalColumns-j-1)?.Number;
                        Console.Write("{0,3}", number);
                    }
                    else
                    {
                        Console.Write("{0,3}", Desk[i][j-additionalColumns]);
                    }
                }

                Console.WriteLine();
            }
            
            foreach (var number in VerticalNumbers)
            {
                number.Reverse();
            }

            foreach (var number in HorizontalNumbers)
            {
                number.Reverse();
            }
        }
    }
}