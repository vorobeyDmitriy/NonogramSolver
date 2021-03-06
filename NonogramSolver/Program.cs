using System.Collections.Generic;
using NonogramSolver.Core.Extensions;
using NonogramSolver.Core.Models;
using NonogramSolver.Core.Services;

namespace NonogramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(new CellsService());
            var puzzle = solver.Solve(GetRealPuzzle());
            puzzle.Print();
        }

        
    }
}