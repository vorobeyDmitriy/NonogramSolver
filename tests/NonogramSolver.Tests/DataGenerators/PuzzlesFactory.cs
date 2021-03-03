using System.Collections.Generic;
using NonogramSolver.Tests.DataGenerators.Puzzles;
using NonogramSolver.Tests.Models;

namespace NonogramSolver.Tests.DataGenerators
{
    public class PuzzlesFactory
    {
        public static List<PuzzleWithSolution> GetPuzzlesWithSolutions()
        {
            return new()
            {
                Castle15X15Generator.GetPuzzleWithSolution,
                House15X15Generator.GetPuzzleWithSolution
            };
        }
    }
}