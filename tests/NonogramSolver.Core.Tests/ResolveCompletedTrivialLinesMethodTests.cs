using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Tests;
using NonogramSolver.Tests.DependencyInjection;
using NonogramSolver.Tests.Modules;
using NUnit.Framework;

namespace NonogramSolver.Core.Tests
{
    public class ResolveCompletedTrivialLinesMethodTests : TestClassBase
    {
        protected override IModule Module => new ResolveCompletedTrivialLinesMethodTestModule();

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_LinesResolved()
        {
            var method = GetService<IMethod>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedTrivialLines = 5;

            method.Execute(puzzle);

            var resolverTrivialLines = puzzle.GetLines().Count(x => x.IsResolved());
            Assert.AreEqual(expectedTrivialLines, resolverTrivialLines);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_CellsFilled()
        {
            var method = GetService<IMethod>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedCellsFilled = 13;

            method.Execute(puzzle);

            var filledCells = puzzle
                              .GetLines(false)
                              .Select(x => x.Cells.Count(c => c.Status == CellStatus.Filled))
                              .Sum();

            Assert.AreEqual(expectedCellsFilled, filledCells);
        }
    }
}