using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class Line
    {
        public List<Cell> Cells { get; set; }
        public List<LineNumber> Numbers { get; set; }

        public bool IsResolved()
        {
            return Numbers.All(x => x.IsResolved);
        }

        public int GetLengthWithSpaces()
        {
            return Numbers.Select(x => x.Number).Sum() + Numbers.Count - 1;
        }
    }
}