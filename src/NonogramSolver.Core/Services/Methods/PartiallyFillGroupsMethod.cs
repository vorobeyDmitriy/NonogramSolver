using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    /// <summary>
    /// Method to split line into groups and get process all possible variants 
    /// </summary>
    /// <remarks>
    /// I.e. 1 3 |_ O _ _ _ _ _| splits into two groups 1 |_| and 1 3 |_ _ _ _ _|
    /// Result of processing is 1 3 |_ O _ _ X _ _ |. Because 1 can appears in 1st and 2nd group
    /// </remarks>
    public class PartiallyFillGroupsMethod : MethodBase
    {
        private readonly IEnumerable<IGroupMethod> _groupMethods;
        private readonly IEnumerable<IIterationMethod> _iterationMethods;

        public PartiallyFillGroupsMethod(ICellsService cellsService, IEnumerable<IGroupMethod> groupMethods,
            IEnumerable<IIterationMethod> iterationMethods)
            : base(cellsService)
        {
            _groupMethods = groupMethods;
            _iterationMethods = iterationMethods;
        }

        public override void ProcessLine(Line line)
        {
            foreach (var method in _iterationMethods)
            {
                method.ProcessLine(line);
            }
                
            var groups = GetLineEmptyCellsGroups(line);
            var unresolvedNumbers = GetUnresolvedNumbers(line.Numbers);
            CrossUnnecessaryGroups(groups, unresolvedNumbers);

            if (groups.Count != 1 && groups.All(x => GroupCanContainsNumbers(x, unresolvedNumbers)))
            {
                return;
            }

            var variants = GetPossibleLineVariant(groups, unresolvedNumbers);
            var variantToFill = GetVariantToFill(variants);

            foreach (var index in variantToFill.Variants)
            {
                foreach (var groupMethod in _groupMethods)
                {
                    var numbers = unresolvedNumbers
                                  .Where((_, i) => index.NumbersIndexes.Contains(i)).ToList();

                    groupMethod.ProcessGroup(groups[index.GroupIndex], numbers);
                }
            }

            foreach (var method in _iterationMethods)
            {
                method.ProcessLine(line);
            }
        }

        private static List<LineNumber> GetUnresolvedNumbers(IEnumerable<LineNumber> numbers)
        {
            var unresolvedNumbers = numbers.Where(x => !x.IsResolved).ToList();
            var numberIndex = 0;
            
            foreach (var number in unresolvedNumbers)
            {
                number.NumberIndex = numberIndex;
                numberIndex++;
            }

            return unresolvedNumbers;
        }
        
        private List<LineVariant> GetPossibleLineVariant(List<Group> groups, List<LineNumber> numbers)
        {
            var possibleVariants = new List<LineVariant>();

            for (var i = 0; i < groups.Count; i++)
            {
                var variants = GetLineVariants(groups.Count, numbers, i);
                possibleVariants.AddRange(variants);
            }

            return possibleVariants.Where(x => x.IsValid(numbers, groups)).ToList();
        }

        private static LineVariant GetVariantToFill(IReadOnlyCollection<LineVariant> possibleVariants)
        {
            var groupedVariants = possibleVariants.SelectMany(x => x.Variants)
                                                  .GroupBy(x => x.GroupIndex, variant => variant.NumbersIndexes)
                                                  .Where(x => x.Count() == possibleVariants.Count)
                                                  .ToList();

            var result = new LineVariant
            {
                Variants = new List<GroupVariant>()
            };

            foreach (var variant in groupedVariants)
            {
                var allVariantNumbers = variant.SelectMany(x => x).ToList();

                var variantNumbers = allVariantNumbers
                                     .GroupBy(x => x)
                                     .Where(x => x.Count() == possibleVariants.Count)
                                     .SelectMany(x => x)
                                     .Distinct()
                                     .ToList();

                result.Variants.Add(new GroupVariant
                {
                    GroupIndex = variant.Key,
                    NumbersIndexes = variantNumbers
                });
            }

            return result;
        }

        private List<LineVariant> GetLineVariants(int groupsCount, IReadOnlyCollection<LineNumber> numbers, int currentGroupIndex)
        {
            var resultLineVariants = new List<LineVariant>();

            if (currentGroupIndex >= groupsCount)
            {
                return new List<LineVariant>();
            }

            for (var j = 0; j < numbers.Count; j++)
            {
                var groupVariants = new List<GroupVariant>();

                var groupVariant = new GroupVariant
                {
                    GroupIndex = currentGroupIndex,
                    NumbersIndexes = numbers.Take(numbers.Count - j).Select(x => x.NumberIndex).ToList()
                };

                if (j == 0)
                {
                    groupVariants.Add(groupVariant);

                    resultLineVariants.Add(new LineVariant
                    {
                        Variants = groupVariants
                    });

                    continue;
                }


                var nextGroupIndex = currentGroupIndex + 1;

                var variantsWithoutSkippingGroups = GetLineVariants(groupsCount,
                    numbers.TakeLast(j).ToList(), nextGroupIndex);

                var variantsWithSkippingGroups = GetVariantsWithSkippingGroup(nextGroupIndex, groupsCount, j,
                    numbers, groupVariant);

                resultLineVariants.AddRange(variantsWithSkippingGroups.SelectMany(x => x));

                if (!variantsWithoutSkippingGroups.Any())
                {
                    continue;
                }

                groupVariants.AddRange(variantsWithoutSkippingGroups.FirstOrDefault()?.Variants!);

                var variantsToAdd = variantsWithoutSkippingGroups.Skip(1).ToList();

                foreach (var variant in variantsToAdd)
                {
                    variant.Variants.Add(groupVariant);
                }

                resultLineVariants.AddRange(variantsToAdd.Select(variant => new LineVariant
                    {Variants = variant.Variants}));

                groupVariants.Add(groupVariant);

                resultLineVariants.Add(new LineVariant
                {
                    Variants = groupVariants
                });
            }

            return resultLineVariants;
        }

        private IEnumerable<List<LineVariant>> GetVariantsWithSkippingGroup(int nextGroupIndex, int groupsCount, int iteration,
            IReadOnlyCollection<LineNumber> numbers, GroupVariant currentGroupVariant)
        {
            var variantsWithSkippingGroups = new List<List<LineVariant>>();

            for (var i = nextGroupIndex + 1; i < groupsCount; i++)
            {
                var lineVariantWithSkipp = GetLineVariants(groupsCount, numbers.TakeLast(iteration).ToList(), i);
                variantsWithSkippingGroups.Add(lineVariantWithSkipp);
            }

            foreach (var variant in variantsWithSkippingGroups.SelectMany(variants => variants))
            {
                variant.Variants.Add(currentGroupVariant);
            }

            return variantsWithSkippingGroups;
        }

        private static bool GroupCanContainsNumbers(Group group, IReadOnlyCollection<LineNumber> numbers)
        {
            var numbersLengthWithSpaces = numbers.Sum(x => x.Number) + numbers.Count - 1;

            return group.Cells.Count >= numbersLengthWithSpaces;
        }

        private static void CrossUnnecessaryGroups(IReadOnlyList<Group> groups, IReadOnlyCollection<LineNumber> unresolvedNumbers)
        {
            foreach (var group in groups)
            {
                if (!(group.Cells.Count < unresolvedNumbers.FirstOrDefault()?.Number))
                {
                    break;
                }

                foreach (var cell in group.Cells)
                {
                    cell.Cross();
                }

                CrossUnnecessaryGroups(groups.Skip(1).ToList(), unresolvedNumbers);
            }

            for (var i = groups.Count - 1; i >= 0; i--)
            {
                var group = groups[i];

                if (!(group.Cells.Count < unresolvedNumbers.LastOrDefault()?.Number))
                {
                    break;
                }

                foreach (var cell in group.Cells)
                {
                    cell.Cross();
                }

                CrossUnnecessaryGroups(groups.TakeLast(groups.Count - 1).ToList(), unresolvedNumbers);
            }
        }

        private static List<Group> GetLineEmptyCellsGroups(Line line)
        {
            var result = new List<Group>();
            var counter = 0;

            foreach (var cell in line.Cells)
            {
                if (cell.Status == CellStatus.Crossed)
                {
                    counter = result.Count;
                }
                else
                {
                    var group = result.ElementAtOrDefault(counter) ?? new Group
                    {
                        Cells = new List<Cell>()
                    };

                    group.Cells.Add(cell);

                    if (result.ElementAtOrDefault(counter) == null)
                    {
                        result.Add(group);
                    }
                }
            }

            return GetValidGroups(result, line);
        }

        private static List<Group> GetValidGroups(IReadOnlyCollection<Group> groups, Line line)
        {
            var emptyGroups = groups
                                  .Where(x => x.Cells.Any(c => c.Status == CellStatus.Empty))
                                  .ToList();
            
            var filledGroups = groups
                                  .Where(x => x.Cells.Any(c => c.Status == CellStatus.Empty))
                                  .ToList();

            var resolvedNumbers = line.Numbers.Where(x => x.IsResolved).ToList();
            
            if (groups.Count == emptyGroups.Count + resolvedNumbers.Count)
            {
                return emptyGroups;
            }

            var groupedNumbers = resolvedNumbers.GroupBy(x => x.Number).ToList();
            
            foreach (var groupNumber in groupedNumbers)
            {
                var searchedGroups = filledGroups.Where(x => x.Cells.Count == groupNumber.Key);

                if (searchedGroups.Count() == groupNumber.Count())
                {
                    filledGroups.RemoveAll(x => x.Cells.Count == groupNumber.Key);
                }
            }
            
            emptyGroups.AddRange(filledGroups);

            return emptyGroups;
        }
    }
}