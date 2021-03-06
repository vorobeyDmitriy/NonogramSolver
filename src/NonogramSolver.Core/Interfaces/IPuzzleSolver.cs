using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface IPuzzleSolver
    {
        Puzzle Solve(int rows, int columns, IEnumerable<List<int>> horizontalNumbers,
            IEnumerable<List<int>> verticalNumbers);

        Puzzle Solve(Puzzle puzzle);
    }
}