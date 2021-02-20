using System.Collections.Generic;
using NonogramSolver.Core;
using NonogramSolver.Core.Extensions;
using NonogramSolver.Core.Models;
using NonogramSolver.Core.Services;

namespace NonogramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(new CellsService());
            var puzzle = solver.Solve(GetThirdPuzzle());
            puzzle.Print();
        }

        private static Puzzle GetFirstPuzzle()
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
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 3
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
                        Number = 2
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 4
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
                    }
                },
            };

            return new Puzzle(5, 4, horizontalLines, verticalLines);
        }

        private static Puzzle GetSecondPuzzle()
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

            return new Puzzle(5, 4, horizontalLines, verticalLines);
        }

        private static Puzzle GetThirdPuzzle()
        {
            var verticalLines = new List<List<LineNumber>>
            {
                new()
                {
                    new LineNumber
                    {
                        Number = 0
                    }
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
                        Number = 0
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 0
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 0
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
                        Number = 1
                    }
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 0
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 0
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 0
                    }
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
                        Number = 1
                    },
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
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
            };

            return new Puzzle(1, 12, horizontalLines, verticalLines);
        }
    }
}