using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class LineVariant
    {
        public List<GroupVariant> Variants { get; set; }
        
        public bool IsValid(List<LineNumber> numbers, List<Group> groups)
        {
            var allVariantsPossible = Variants.All(x => x.IsValid(numbers, groups));

            if (!allVariantsPossible)
            {
                return false;
            }

            var numberIndexes = Variants.SelectMany(x => x.NumbersIndexes).ToList();
            
            return IsSequenceValid(numberIndexes);
        }

        private static bool IsSequenceValid(IReadOnlyCollection<int> sequence)
        {
            var orderedSequence = sequence.OrderBy(x => x);
            var result = orderedSequence.Select((x, i) => x == i).All(x=>x);

            return result;
        }
    }
}