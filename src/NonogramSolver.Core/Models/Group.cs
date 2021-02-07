using System.Collections.Generic;

namespace NonogramSolver.Core.Models
{
    public class Group
    {
        public int StartIndex { get; set; }
        public List<Cell> Cells { get; set; }
        public List<int> AvailableNumberIndexes { get; set; }
    }
}