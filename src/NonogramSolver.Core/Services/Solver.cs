using System.Collections.Generic;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;
using NonogramSolver.Core.Services.Methods;

namespace NonogramSolver.Core.Services
{
    public class Solver : ISolver
    {
        private const int MaxIterations = 1000;

        private readonly IMethod _completedLines;
        private readonly IMethod _trivialLinesMethod;
        private readonly IMethod _partiallyNumbersMethod;
        private readonly IMethod _partiallyGroupMethod;
        
        public Solver(ICellsService cellsService)
        {
            _completedLines = new ResolveCompletedLinesMethod(cellsService);
            _trivialLinesMethod = new ResolveTrivialLinesMethod(cellsService);
            _partiallyNumbersMethod = new PartiallyFillNumberMethod(cellsService);
            var resolveNumbersMethod = new ResolvedEdgeNumbersMethod(cellsService);
            _partiallyGroupMethod = new PartiallyFillGroupsMethod(cellsService, new List<IGroupMethod>
            {
                resolveNumbersMethod,
                (IGroupMethod) _partiallyNumbersMethod,
            }, new List<IIterationMethod>
            {
                resolveNumbersMethod,
                (IIterationMethod) _completedLines,
                (IIterationMethod) _partiallyNumbersMethod,
            });
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
            _trivialLinesMethod.ProcessPuzzle(puzzle);

            var maxIterations = MaxIterations;

            while (!puzzle.IsResolved() && maxIterations > 0)
            {
                _partiallyGroupMethod.ProcessPuzzle(puzzle);
                
                maxIterations--;
            }

            return puzzle;
        }
    }
}