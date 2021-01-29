using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Tests;
using NonogramSolver.Tests.DependencyInjection;
using NonogramSolver.Tests.Modules;
using NUnit.Framework;

namespace NonogramSolver.Core.Tests
{
    public class SolverTests : TestClassBase
    {
        protected override IModule Module => new SolverTestModule();

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_LinesResolved()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedTrivialLines = 5;

            solver.FillTrivialLines(puzzle);
            solver.FillTrivialLines(puzzle);

            var resolverTrivialLines = puzzle.GetLines().Count(x => x.IsResolved());
            Assert.AreEqual(expectedTrivialLines, resolverTrivialLines);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_CellsFilled()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedCellsFilled = 13;

            solver.FillTrivialLines(puzzle);
            solver.FillTrivialLines(puzzle);

            var filledCells = puzzle
                              .GetLines(false)
                              .Select(x => x.Cells.Count(c => c.Status == CellStatus.Filled))
                              .Sum();

            Assert.AreEqual(expectedCellsFilled, filledCells);
        }
    }
}