using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class GroupVariant
    {
        public int GroupIndex { get; init; }
        public List<int> NumbersIndexes { get; init; }

        public bool IsValid(IEnumerable<LineNumber> allNumbers, List<Group> groups)
        {
            var group = groups[GroupIndex];

            var numbers = allNumbers.Where((_, i) => NumbersIndexes.Contains(i)).ToList();
            
            var numbersLengthWithSpaces = numbers.Sum(x => x.Number) + numbers.Count - 1;

            return group.Cells.Count >= numbersLengthWithSpaces;
        }
    }
}