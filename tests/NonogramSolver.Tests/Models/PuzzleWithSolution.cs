using NonogramSolver.Core.Models;

namespace NonogramSolver.Tests.Models
{
    public class PuzzleWithSolution
    {
        public Puzzle Puzzle { get; set; }
        public Cell[][] Solution { get; set; }
        public string Name { get; set; }
    }
}