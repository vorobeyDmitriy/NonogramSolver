using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class LineVariant
    {
        public List<GroupVariant> Variants { get; set; }
        
        public bool IsValid(List<int> numbers, List<Group> groups)
        {
            foreach (var variant in Variants)
            {
                var group = groups[variant.GroupIndex];
                var groupNumbers = numbers.Where((_, index) => variant.NumbersIndexes.Contains(index));
                
                var numbersLengthWithSpaces = groupNumbers.Sum(x => x) + numbers.Count - 1;

                if (group.Cells.Count < numbersLengthWithSpaces)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}