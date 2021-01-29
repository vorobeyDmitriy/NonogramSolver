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
        public void FillTrivialLines_PuzzleWithTrivialLines_HorizontalCellsFilled()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedTrivialLines = 3;

            solver.FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);

            var resolverTrivialLines = puzzle.GetLines(true).Count(x => x.IsResolved());
            Assert.AreEqual(expectedTrivialLines, resolverTrivialLines);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_HorizontalLinesFilled()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedCellsFilled = 10;

            solver.FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);

            var filledCells = puzzle
                              .GetLines(true)
                              .Select(x => x.Cells.Count(c => c.Status == CellStatus.Filled))
                              .Sum();

            Assert.AreEqual(expectedCellsFilled, filledCells);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_VerticalLinesResolved()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedTrivialLines = 2;

            solver.FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);

            var resolverTrivialLines = puzzle.GetLines(false).Count(x => x.IsResolved());

            Assert.AreEqual(expectedTrivialLines, resolverTrivialLines);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_VerticalCellsFilled()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedCellsFilled = 8;

            solver.FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);

            var filledCells = puzzle
                              .GetLines(true)
                              .Select(x => x.Cells.Count(c => c.Status == CellStatus.Filled))
                              .Sum();

            Assert.AreEqual(expectedCellsFilled, filledCells);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_TotalLinesResolved()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedTrivialLines = 5;

            solver.FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);
            solver.FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);

            var resolverTrivialLines = puzzle.GetLines().Count(x => x.IsResolved());
            Assert.AreEqual(expectedTrivialLines, resolverTrivialLines);
        }

        [Test]
        public void FillTrivialLines_PuzzleWithTrivialLines_TotalCells()
        {
            var solver = GetService<ISolver>();
            var puzzle = DataGenerator.GetPuzzleWithTrivialLines();
            const int expectedCellsFilled = 13;

            solver.FillTrivialLines(puzzle, true, puzzle.Rows, puzzle.Columns);
            solver.FillTrivialLines(puzzle, false, puzzle.Columns, puzzle.Rows);

            var filledCells = puzzle
                              .GetLines(false)
                              .Select(x => x.Cells.Count(c => c.Status == CellStatus.Filled))
                              .Sum();

            Assert.AreEqual(expectedCellsFilled, filledCells);
        }
    }
}