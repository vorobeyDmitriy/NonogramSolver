using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;
using NonogramSolver.Core.Services.Methods;

namespace NonogramSolver.Core.Services
{
    public class PuzzleSolver : IPuzzleSolver
    {
        private const int MaxIterations = 10000;
        private readonly IEnumerable<IMethod> _methods;

        public PuzzleSolver(IEnumerable<IMethod> methods)
        {
            _methods = methods;
        }

        public Puzzle Solve(int rows, int columns, IEnumerable<List<int>> horizontalNumbers,
            IEnumerable<List<int>> verticalNumbers)
        {
            var horizontal = horizontalNumbers.Select(x => x.Select(c => new LineNumber
                                              {
                                                  Number = c
                                              }).ToList())
                                              .ToList();
            
            var vertical = verticalNumbers.Select(x => x.Select(c => new LineNumber
                                          {
                                              Number = c
                                          }).ToList())
                                          .ToList();

            var puzzle = new Puzzle(rows, columns, horizontal, vertical);
            puzzle = Solve(puzzle);

            return puzzle;
        }

        public Puzzle Solve(Puzzle puzzle)
        {
            var maxIterations = MaxIterations;

            while (!puzzle.IsResolved() && maxIterations > 0)
            {
                foreach (var method in _methods)
                {
                    method.ProcessPuzzle(puzzle);
                }

                maxIterations--;
            }

            return puzzle;
        }
    }
}