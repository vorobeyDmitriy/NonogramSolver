using System;
using System.Linq;
using NonogramSolver.Enumerations;
using NonogramSolver.Models;

namespace NonogramSolver
{
    public class PuzzlePrintService
    {
        public void Print(Puzzle puzzle)
        {
            var additionalRows = puzzle.VerticalNumbers.Select(x => x.Count).Max();
            var additionalColumns = puzzle.HorizontalNumbers.Select(x => x.Count).Max();

            foreach (var number in puzzle.VerticalNumbers)
            {
                number.Reverse();
            }

            foreach (var number in puzzle.HorizontalNumbers)
            {
                number.Reverse();
            }

            PrintHeaderOfPuzzle(puzzle, additionalRows, additionalColumns);
            PrintBodyOfPuzzle(puzzle, additionalColumns);
            
            foreach (var number in puzzle.VerticalNumbers)
            {
                number.Reverse();
            }

            foreach (var number in puzzle.HorizontalNumbers)
            {
                number.Reverse();
            }
        }

        private void PrintHeaderOfPuzzle(Puzzle puzzle, int additionalRows, int additionalColumns)
        {
            for (var i = 0; i < additionalRows; i++)
            {
                for (var j = 0; j < puzzle.Columns + additionalColumns; j++)
                {
                    if (j < additionalColumns)
                    {
                        Write(string.Empty);
                    }
                    else
                    {
                        var number = puzzle.VerticalNumbers[j - additionalColumns]
                                           .ElementAtOrDefault(additionalRows - i - 1);

                        Write(number?.Number, ConsoleColor.DarkRed,number?.IsResolved == true);
                    }
                }

                Console.WriteLine();
            }
        }

        private void PrintBodyOfPuzzle(Puzzle puzzle, int additionalColumns)
        {
            for (var i = 0; i < puzzle.Rows; i++)
            {
                for (var j = 0; j < puzzle.Columns+additionalColumns; j++)
                {
                    if (j < additionalColumns)
                    {
                        var number = puzzle.HorizontalNumbers[i].ElementAtOrDefault(additionalColumns-j-1);

                        Write(number?.Number, ConsoleColor.DarkRed,number?.IsResolved == true);
                    }
                    else
                    {
                        var cell = puzzle.Desk[i][j - additionalColumns];
                        ConsoleColor color;

                        if (cell.Status == CellStatus.Filled)
                        {
                            color = ConsoleColor.White;
                        }
                        else
                        {
                            color = ConsoleColor.DarkGray;
                        }
                        
                        Write(puzzle.Desk[i][j-additionalColumns], color, true);
                    }
                }

                Console.WriteLine();
            }
        }

        private void Write(object value, ConsoleColor color = ConsoleColor.DarkGray, bool colorNeeds = false)
        {
            if (colorNeeds)
            {
                Console.ForegroundColor = color;
            }
                        
            Console.Write("{0,3}", value);
            Console.ResetColor();
        }
    }
}