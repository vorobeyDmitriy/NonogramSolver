using System.Collections.Generic;

namespace NonogramSolver.Core.Models
{
    public class GroupVariant
    {
        public int GroupIndex { get; set; }
        public List<int> NumbersIndexes { get; set; }
    }
}