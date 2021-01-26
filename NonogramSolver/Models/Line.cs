using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Models
{
    public class Line
    {
        public List<Cell> Cells { get; set; }
        public List<LineNumber> Numbers { get; set; }
        
        public int GetLengthWithSpaces()
        {
            return Numbers.Select(x=>x.Number).Sum() + Numbers.Count - 1;
        }
    }
}