using System.Collections.Generic;
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
            var puzzle = solver.Solve(GetRealPuzzle());
            puzzle.Print();
        }

        private static Puzzle GetRealPuzzle()
        {
            var verticalLines = new List<List<LineNumber>>
            {
                new()
                {
                    new LineNumber
                    {
                        Number = 12
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
                        Number = 4
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
                        Number = 5
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
                        Number = 8
                    },
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
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 4
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
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 5
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
                        Number = 4
                    },
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
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 12
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
                },
                new()
                {
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
                    },
                },
                new()
                {
                    new LineNumber
                    {
                        Number =2
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number =1
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number =2
                    },
                   
                },
                new()
                {
                    new LineNumber
                    {
                        Number = 5
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
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
                    },
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
                        Number = 7
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
                    new LineNumber
                    {
                        Number = 3
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
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
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 3
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
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 3
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
                        Number = 1
                    },
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
                        Number = 15
                    }
                },
            };

            return new Puzzle(15, 15, horizontalLines, verticalLines);
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
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                },
            };

            return new Puzzle(1, 12, horizontalLines, verticalLines);
        }
        
        //resolve edge numbers
        private static Puzzle GetFourthPuzzle()
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
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                    new LineNumber
                    {
                        Number = 4
                    },
                },
            };

            return new Puzzle(1, 15, horizontalLines, verticalLines);
        }
        
        //resolve edge numbers
        private static Puzzle GetFifthPuzzle()
        {
            // puzzle.GetLine(0, true).Cells[8].Fill();
            // puzzle.GetLine(0, true).Cells[9].Cross();
            // puzzle.GetLine(0, true).Cells[13].Cross();
            // puzzle.GetLine(0, true).Cells[14].Fill();
            // puzzle.HorizontalNumbers.LastOrDefault().LastOrDefault().Resolve();
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
                    new LineNumber
                    {
                        Number = 1
                    },
                },
            };

            return new Puzzle(1, 15, horizontalLines, verticalLines);
        }
        
        //resolve edge numbers
        //1 4 2 1
        private static Puzzle GetSixPuzzle()
        {
            // puzzle.GetLine(0, true).Cells[5].Fill();
            // puzzle.GetLine(0, true).Cells[6].Fill();
            // puzzle.GetLine(0, true).Cells[7].Fill();
            // puzzle.GetLine(0, true).Cells[8].Fill();
            // puzzle.GetLine(0, true).Cells[9].Cross();
            // puzzle.GetLine(0, true).Cells[10].Fill();
            // puzzle.GetLine(0, true).Cells[11].Fill();
            // puzzle.GetLine(0, true).Cells[12].Cross();
            // puzzle.GetLine(0, true).Cells[13].Cross();
            // puzzle.GetLine(0, true).Cells[14].Fill();
            // puzzle.HorizontalNumbers.LastOrDefault().LastOrDefault().Resolve();
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
                        Number = 4
                    },
                    new LineNumber
                    {
                        Number = 2
                    },
                    new LineNumber
                    {
                        Number = 1
                    },
                },
            };

            return new Puzzle(1, 15, horizontalLines, verticalLines);
        }
    }
}