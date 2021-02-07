using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface ICellsService
    {
        void CrossCells(IEnumerable<Cell> cells);

        void FillCells(IEnumerable<Cell> cells);

        void FillNumber(List<Cell> cells, LineNumber number, int startIndex);
        
        void ResolveNumbers(IEnumerable<LineNumber> numbers);
    }
}