﻿using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface ISolver
    {
        void CheckLinesForResolving(Puzzle puzzle);
        
        void FillCrossedNumbers(Puzzle puzzle);
        
        void FillEdgeNumbers(Puzzle puzzle);
        
        void FillTrivialLines(Puzzle puzzle);
        
        Puzzle Solve(int rows, int columns, List<List<LineNumber>> horizontalNumbers,
            List<List<LineNumber>> verticalNumbers);

        Puzzle Solve(Puzzle puzzle);
    }
}