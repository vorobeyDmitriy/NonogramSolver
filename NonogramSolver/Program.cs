using System.Collections.Generic;
using NonogramSolver.Core;
using NonogramSolver.Core.Extensions;
using NonogramSolver.Core.Models;

namespace NonogramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var verticalLines = new List<List<LineNumber>>
            {
                new()
                {
                    new LineNumber
                    {
                        Number = 7
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 5
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 1
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 5
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 1
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 5
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
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 1
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
                    new LineNumber
                    {
                        Number = 2
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
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
            };

            var solver = new Solver();
            var puzzle = solver.Solve(7, 7, horizontalLines, verticalLines);
            puzzle.Print();
        }
    }
}