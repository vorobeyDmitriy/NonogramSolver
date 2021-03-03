using System.Collections.Generic;
using NonogramSolver.Core.Models;
using NonogramSolver.Tests.Models;

namespace NonogramSolver.Tests.DataGenerators.Puzzles
{
    public static class House15X15Generator
    {
        public static PuzzleWithSolution GetPuzzleWithSolution => new()
        {
            Puzzle = GetPuzzle(),
            Solution = GetSolution(),
            Name = "House15X15"
        };

        private static Puzzle GetPuzzle()
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
                        Number = 2
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

        private static Cell[][] GetSolution()
        {
            const int rows = 15;
            const int columns = 15;
            var desk = new Cell[rows][];

            for (var i = 0; i < rows; i++)
            {
                desk[i] = new Cell[columns];
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    desk[i][j] = new Cell();
                }
            }

            desk[0][0].Cross();
            desk[0][1].Cross();
            desk[0][2].Cross();
            desk[0][3].Cross();
            desk[0][4].Cross();
            desk[0][5].Cross();
            desk[0][6].Fill();
            desk[0][7].Cross();
            desk[0][8].Cross();
            desk[0][9].Cross();
            desk[0][10].Cross();
            desk[0][11].Cross();
            desk[0][12].Cross();
            desk[0][13].Cross();
            desk[0][14].Cross();

            desk[1][0].Cross();
            desk[1][1].Cross();
            desk[1][2].Cross();
            desk[1][3].Cross();
            desk[1][4].Cross();
            desk[1][5].Cross();
            desk[1][6].Fill();
            desk[1][7].Fill();
            desk[1][8].Cross();
            desk[1][9].Cross();
            desk[1][10].Cross();
            desk[1][11].Cross();
            desk[1][12].Cross();
            desk[1][13].Cross();
            desk[1][14].Cross();

            desk[2][0].Cross();
            desk[2][1].Cross();
            desk[2][2].Cross();
            desk[2][3].Cross();
            desk[2][4].Cross();
            desk[2][5].Cross();
            desk[2][6].Fill();
            desk[2][7].Fill();
            desk[2][8].Fill();
            desk[2][9].Cross();
            desk[2][10].Cross();
            desk[2][11].Cross();
            desk[2][12].Cross();
            desk[2][13].Cross();
            desk[2][14].Cross();

            desk[3][0].Fill();
            desk[3][1].Fill();
            desk[3][2].Cross();
            desk[3][3].Fill();
            desk[3][4].Fill();
            desk[3][5].Cross();
            desk[3][6].Fill();
            desk[3][7].Cross();
            desk[3][8].Cross();
            desk[3][9].Cross();
            desk[3][10].Fill();
            desk[3][11].Fill();
            desk[3][12].Cross();
            desk[3][13].Fill();
            desk[3][14].Fill();

            desk[4][0].Fill();
            desk[4][1].Fill();
            desk[4][2].Fill();
            desk[4][3].Fill();
            desk[4][4].Fill();
            desk[4][5].Cross();
            desk[4][6].Fill();
            desk[4][7].Cross();
            desk[4][8].Cross();
            desk[4][9].Cross();
            desk[4][10].Fill();
            desk[4][11].Fill();
            desk[4][12].Fill();
            desk[4][13].Fill();
            desk[4][14].Fill();

            desk[5][0].Fill();
            desk[5][1].Cross();
            desk[5][2].Cross();
            desk[5][3].Cross();
            desk[5][4].Fill();
            desk[5][5].Cross();
            desk[5][6].Fill();
            desk[5][7].Cross();
            desk[5][8].Cross();
            desk[5][9].Cross();
            desk[5][10].Fill();
            desk[5][11].Cross();
            desk[5][12].Cross();
            desk[5][13].Cross();
            desk[5][14].Fill();

            desk[6][0].Fill();
            desk[6][1].Cross();
            desk[6][2].Fill();
            desk[6][3].Cross();
            desk[6][4].Fill();
            desk[6][5].Cross();
            desk[6][6].Fill();
            desk[6][7].Cross();
            desk[6][8].Cross();
            desk[6][9].Cross();
            desk[6][10].Fill();
            desk[6][11].Cross();
            desk[6][12].Fill();
            desk[6][13].Cross();
            desk[6][14].Fill();

            desk[7][0].Fill();
            desk[7][1].Cross();
            desk[7][2].Fill();
            desk[7][3].Cross();
            desk[7][4].Fill();
            desk[7][5].Fill();
            desk[7][6].Fill();
            desk[7][7].Fill();
            desk[7][8].Fill();
            desk[7][9].Fill();
            desk[7][10].Fill();
            desk[7][11].Cross();
            desk[7][12].Fill();
            desk[7][13].Cross();
            desk[7][14].Fill();

            desk[8][0].Fill();
            desk[8][1].Cross();
            desk[8][2].Cross();
            desk[8][3].Cross();
            desk[8][4].Cross();
            desk[8][5].Cross();
            desk[8][6].Cross();
            desk[8][7].Cross();
            desk[8][8].Cross();
            desk[8][9].Cross();
            desk[8][10].Cross();
            desk[8][11].Cross();
            desk[8][12].Cross();
            desk[8][13].Cross();
            desk[8][14].Fill();

            desk[9][0].Fill();
            desk[9][1].Cross();
            desk[9][2].Cross();
            desk[9][3].Fill();
            desk[9][4].Cross();
            desk[9][5].Cross();
            desk[9][6].Cross();
            desk[9][7].Cross();
            desk[9][8].Cross();
            desk[9][9].Cross();
            desk[9][10].Cross();
            desk[9][11].Fill();
            desk[9][12].Cross();
            desk[9][13].Cross();
            desk[9][14].Fill();

            desk[10][0].Fill();
            desk[10][1].Cross();
            desk[10][2].Fill();
            desk[10][3].Fill();
            desk[10][4].Fill();
            desk[10][5].Cross();
            desk[10][6].Cross();
            desk[10][7].Fill();
            desk[10][8].Cross();
            desk[10][9].Cross();
            desk[10][10].Fill();
            desk[10][11].Fill();
            desk[10][12].Fill();
            desk[10][13].Cross();
            desk[10][14].Fill();

            desk[11][0].Fill();
            desk[11][1].Cross();
            desk[11][2].Cross();
            desk[11][3].Fill();
            desk[11][4].Cross();
            desk[11][5].Cross();
            desk[11][6].Fill();
            desk[11][7].Fill();
            desk[11][8].Fill();
            desk[11][9].Cross();
            desk[11][10].Cross();
            desk[11][11].Fill();
            desk[11][12].Cross();
            desk[11][13].Cross();
            desk[11][14].Fill();

            desk[12][0].Fill();
            desk[12][1].Cross();
            desk[12][2].Cross();
            desk[12][3].Fill();
            desk[12][4].Cross();
            desk[12][5].Cross();
            desk[12][6].Fill();
            desk[12][7].Fill();
            desk[12][8].Fill();
            desk[12][9].Cross();
            desk[12][10].Cross();
            desk[12][11].Fill();
            desk[12][12].Cross();
            desk[12][13].Cross();
            desk[12][14].Fill();

            desk[13][0].Fill();
            desk[13][1].Cross();
            desk[13][2].Cross();
            desk[13][3].Cross();
            desk[13][4].Cross();
            desk[13][5].Cross();
            desk[13][6].Fill();
            desk[13][7].Fill();
            desk[13][8].Fill();
            desk[13][9].Cross();
            desk[13][10].Cross();
            desk[13][11].Cross();
            desk[13][12].Cross();
            desk[13][13].Cross();
            desk[13][14].Fill();

            desk[14][0].Fill();
            desk[14][1].Fill();
            desk[14][2].Fill();
            desk[14][3].Fill();
            desk[14][4].Fill();
            desk[14][5].Fill();
            desk[14][6].Fill();
            desk[14][7].Fill();
            desk[14][8].Fill();
            desk[14][9].Fill();
            desk[14][10].Fill();
            desk[14][11].Fill();
            desk[14][12].Fill();
            desk[14][13].Fill();
            desk[14][14].Fill();

            return desk;
        }
    }
}