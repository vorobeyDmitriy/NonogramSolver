using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;

namespace NonogramSolver.Core.Models
{
    public class Line
    {
        public List<Cell> Cells { get; set; }
        public List<LineNumber> Numbers { get; set; }
        public bool IsRow { get; set; }

        public bool IsResolved()
        {
            return Numbers.All(x => x.IsResolved) && Cells.All(x => x.Status != CellStatus.Empty);
        }

        public int GetLengthWithSpaces()
        {
            return Numbers.Select(x => x.Number).Sum() + Numbers.Count - 1;
        }
    }
}