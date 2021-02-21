using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class GroupVariant
    {
        public int GroupIndex { get; set; }
        public List<int> NumbersIndexes { get; set; }

        public bool IsValid(List<LineNumber> allNumbers, List<Group> groups)
        {
            var group = groups[GroupIndex];

            var numbers = allNumbers.Where((x, i) => NumbersIndexes.Contains(i)).ToList();
            
            var numbersLengthWithSpaces = numbers.Sum(x => x.Number) + numbers.Count - 1;

            return group.Cells.Count >= numbersLengthWithSpaces;
        }
    }
}