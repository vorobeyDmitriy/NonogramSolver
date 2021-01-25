using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Models
{
    public class Puzzle
    {
        public List<List<int>> VerticalNumbers { get; set; }
        public List<List<int>> HorizontalNumbers { get; set; }
        public Cell[][] Desk { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }

        public Puzzle(int rows, int columns, List<List<int>> horizontalNumbers, List<List<int>> verticalNumbers)
        {
            VerticalNumbers = verticalNumbers;
            HorizontalNumbers = horizontalNumbers;
            Columns = columns;
            Rows = rows;
            Desk = new Cell[rows][];

            for (var i = 0; i < columns; i++)
            {
                Desk[i] = new Cell[columns];
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
    }
}