using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;

namespace NonogramSolver.Core.Models
{
    public class Line
    {
        public List<Cell> Cells { get; init; }
        public List<LineNumber> Numbers { get; init; }

        public bool IsResolved()
        {
            return Numbers.All(x => x.IsResolved) && Cells.All(x => x.Status != CellStatus.Empty);
        }
    }
}