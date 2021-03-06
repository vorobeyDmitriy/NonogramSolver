using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver.Core.Models
{
    public class LineVariant
    {
        public List<GroupVariant> Variants { get; init; }

        public bool IsValid(List<LineNumber> numbers, List<Group> groups)
        {
            var allVariantsPossible = Variants.All(x => x.IsValid(numbers, groups));

            return allVariantsPossible;
        }
    }
}