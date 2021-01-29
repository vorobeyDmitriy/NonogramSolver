using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Tests
{
    public static class DataGenerator
    {
        public static Puzzle GetPuzzleWithTrivialLines() 
        {
            var verticalLines = new List<List<LineNumber>>
            {
                new()
                {
                    new LineNumber
                    {
                        Number = 3
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 3
                    }
                },
            };
            
            var horizontalLines = new List<List<LineNumber>>
            {
                new()
                {
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 4
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 1
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 3
                    },
                },
            };

            return new Puzzle(5, 4, horizontalLines, verticalLines);
        }
    }
}