using System.Collections.Generic;
using NonogramSolver.Core.Extensions;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;
using NonogramSolver.Core.Services.Methods;

namespace NonogramSolver.Core.Services
{
    public class Solver : ISolver
    {
        private const int MaxIterations = 1000;

        private readonly ICellsService _cellsService;
        private readonly IMethod _completedLines;
        private readonly IMethod _trivialLinesMethod;
        private readonly IMethod _edgeNumbersMethod;
        private readonly IMethod _partiallyNumbersMethod;
        private readonly IMethod _partiallyGroupMethod;
        
        public Solver(ICellsService cellsService)
        {
            _cellsService = cellsService;
            _completedLines = new ResolveCompletedLinesMethod(_cellsService);
            _trivialLinesMethod = new ResolveTrivialLinesMethod(_cellsService);
            _edgeNumbersMethod = new ResolveEdgeNumbersMethod(_cellsService);
            _partiallyNumbersMethod = new PartiallyFillNumberMethod(_cellsService);
            var resolveNumbersMethod = new CheckLineResolvedNumbers(_cellsService);
            _partiallyGroupMethod = new PartiallyFillGroupsMethod(_cellsService, new List<IGroupMethod>
            {
                (IGroupMethod) _completedLines,
                (IGroupMethod) _partiallyNumbersMethod,
                (IGroupMethod) _edgeNumbersMethod,
            }, new List<IIterationMethod>
            {
                resolveNumbersMethod,
                (IIterationMethod) _completedLines,
                (IIterationMethod) _partiallyNumbersMethod,
                (IIterationMethod) _edgeNumbersMethod,
                (IIterationMethod) _edgeNumbersMethod,
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
            _trivialLinesMethod.Execute(puzzle);
            _completedLines.Execute(puzzle);
            puzzle.Print();


            var maxIterations = MaxIterations;

            while (!puzzle.IsResolved() && maxIterations > 0)
            {
                _edgeNumbersMethod.Execute(puzzle);
                _partiallyNumbersMethod.Execute(puzzle);
                _partiallyGroupMethod.Execute(puzzle);
                puzzle.Print();

                maxIterations--;
            }

            return puzzle;
        }
    }
}