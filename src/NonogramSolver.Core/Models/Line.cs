using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class Line
    {
        public List<Cell> Cells { get; set; }
        public List<LineNumber> Numbers { get; set; }
        private bool IsResolved { get; set; }

        public void Resolve()
        {
            IsResolved = true;
        }
        
        public int GetLengthWithSpaces()
        {
            return Numbers.Select(x=>x.Number).Sum() + Numbers.Count - 1;
        }
    }
}