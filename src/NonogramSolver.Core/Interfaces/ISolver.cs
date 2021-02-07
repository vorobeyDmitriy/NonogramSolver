using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface ISolver
    {
        Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers);

        Puzzle Solve(Puzzle puzzle);
    }
}