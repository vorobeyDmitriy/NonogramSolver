using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class LineVariant
    {
        public List<GroupVariant> Variants { get; set; }
        
        public bool IsValid(int numbersCount)
        {
            var maxIndex = Variants.Max(x => x.NumbersIndexes.Max()) + 1;

            return maxIndex == numbersCount;
        }
    }
}