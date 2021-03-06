using System.Collections.Generic;
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

        public Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers)
        {
            var puzzle = new Puzzle(rows, columns, horizontalNumbers, verticalNumbers);
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