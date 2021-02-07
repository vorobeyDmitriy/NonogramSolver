using System.Collections.Generic;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services
{
    public class CellsService : ICellsService
    {
        public void CrossCells(IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Cross();
            }
        }

        public void FillCells(IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Fill();
            }
        }

        public void FillNumber(List<Cell> cells, LineNumber number, int startIndex)
        {
            for (var i = startIndex; i < startIndex + number.Number; i++)
            {
                cells[i].Fill();
            }

            var lastCrossIndex = startIndex + number.Number;

            if (lastCrossIndex < cells.Count)
            {
                cells[lastCrossIndex].Cross();
            }

            number.Resolve(startIndex, startIndex + number.Number - 1);
        }

        public void ResolveNumbers(IEnumerable<LineNumber> numbers)
        {
            foreach (var number in numbers)
            {
                number.Resolve();
            }
        }
    }
}