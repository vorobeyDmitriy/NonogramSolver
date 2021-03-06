using System.Collections.Generic;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;
using NonogramSolver.Tests;
using NonogramSolver.Tests.DataGenerators;
using NonogramSolver.Tests.DependencyInjection;
using NonogramSolver.Tests.Models;
using NonogramSolver.Tests.Modules;
using NUnit.Framework;

namespace NonogramSolver.Core.Tests
{
    public class PuzzleSolverTests: TestClassBase
    {
        protected override IModule Module => new PuzzleSolverTestModule();


        [TestCaseSource(typeof(PuzzlesFactory), nameof(PuzzlesFactory.GetPuzzlesWithSolutions))]
        public void Solve_DifferentPuzzles_Resolved(PuzzleWithSolution puzzleWithSolution)
        {
            var solver = GetService<IPuzzleSolver>();
            
            var solvedPuzzle = solver.Solve(puzzleWithSolution.Puzzle);
            
            Assert.True(IsArrayEquals(puzzleWithSolution.Solution, solvedPuzzle.Desk), puzzleWithSolution.Name);
        }
        
        private static bool IsArrayEquals(IReadOnlyList<Cell[]> array1, IReadOnlyList<Cell[]> array2)
        {
            if (array1.Count != array2.Count)
            {
                return false;
            }

            for (var i = 0; i < array1.Count; i++)
            {
                for (var j = 0; j < array1[i].Length; j++)
                {
                    if (array1[i][j].Status != array2[i][j].Status)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
    }
}