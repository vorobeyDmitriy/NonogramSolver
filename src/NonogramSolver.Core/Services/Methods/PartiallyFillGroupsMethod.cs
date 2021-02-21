using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    public class PartiallyFillGroupsMethod : MethodBase
    {
        public PartiallyFillGroupsMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void Execute(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                var groups = GetLineEmptyCellsGroups(line);
                var unresolvedNumbers = line.Numbers.Where(x => !x.IsResolved).ToList();

                CrossUnnecessaryGroups(groups, unresolvedNumbers);

                if (groups.All(x => GroupCanContainsNumbers(x, unresolvedNumbers)))
                {
                    continue;
                }

                var variants = GetPossibleLineVariants(groups, unresolvedNumbers);

                //todo: get common numbers for all groups
            }
        }

        private List<LineVariant> GetPossibleLineVariants(List<Group> groups, List<LineNumber> numbers)
        {
            var result = new List<LineVariant>();

            for (int i = 0; i < groups.Count; i++)
            {
                var variants = GetLineVariants(groups.Count, numbers, i);
                result.AddRange(variants);
            }

            return result.Where(x=>x.IsValid(numbers, groups)).ToList();
        }

        private List<LineVariant> GetLineVariants(int groupsCount, List<LineNumber> numbers, int currentGroupIndex,
            int numberOffset = 0)
        {
            var resultLineVariants = new List<LineVariant>();
            
            if (currentGroupIndex >= groupsCount)
            {
                return new List<LineVariant>();
            }
            
            for (int j = 0; j < numbers.Count; j++)
            {
                var groupVariants = new List<GroupVariant>();
                var groupVariant = new GroupVariant
                {
                    GroupIndex = currentGroupIndex,
                    NumbersIndexes = numbers.Take(numbers.Count-j).Select((_, i) => i+numberOffset).ToList()
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
                    numbers.TakeLast(j).ToList(), nextGroupIndex, numbers.Count-j);

                var variantsWithSkippingGroups = new List<List<LineVariant>>();

                for (int i = nextGroupIndex+1; i < groupsCount; i++)
                {
                    var lineVariantWithSkipp = GetLineVariants(groupsCount, numbers.TakeLast(j).ToList(), i, numbers.Count - j);
                    variantsWithSkippingGroups.Add(lineVariantWithSkipp);
                }

                foreach (var variants in variantsWithSkippingGroups)
                {
                    foreach (var variant in variants)
                    {
                        variant.Variants.Add(groupVariant);
                    }
                }
                
                resultLineVariants.AddRange(variantsWithSkippingGroups.SelectMany(x=>x));
                
                if (!variantsWithoutSkippingGroups.Any())
                {
                    continue;
                }
                
                groupVariants.AddRange(variantsWithoutSkippingGroups.FirstOrDefault().Variants);

                var variantsToAdd = variantsWithoutSkippingGroups.Skip(1).ToList();
                
                foreach (var variant in variantsToAdd)
                {
                    variant.Variants.Add(groupVariant);
                }
                
                resultLineVariants.AddRange(variantsToAdd.Select(variant => new LineVariant {Variants = variant.Variants}));
                
                groupVariants.Add(groupVariant);

                resultLineVariants.Add(new LineVariant
                {
                    Variants = groupVariants
                });
            }

            return resultLineVariants;
        }
        
        private bool GroupCanContainsNumbers(Group group, List<LineNumber> numbers)
        {
            //todo: repeat
            var numbersLengthWithSpaces = numbers.Sum(x => x.Number) + numbers.Count - 1;

            return group.Cells.Count >= numbersLengthWithSpaces;
        }

        private static void CrossUnnecessaryGroups(List<Group> groups, List<LineNumber> unresolvedNumbers)
        {
            for (var i = 0; i < groups.Count; i++)
            {
                var group = groups[i];

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

        private List<Group> GetLineEmptyCellsGroups(Line line)
        {
            var result = new List<Group>();
            var counter = 0;

            for (var i = 0; i < line.Cells.Count; i++)
            {
                if (line.Cells[i].Status == CellStatus.Crossed)
                {
                    counter = result.Count;
                }
                else
                {
                    var group = result.ElementAtOrDefault(counter) ?? new Group
                    {
                        Cells = new List<Cell>(),
                        StartIndex = i,
                        AvailableNumberIndexes = new List<int>()
                    };

                    group.Cells.Add(line.Cells[i]);

                    if (result.ElementAtOrDefault(counter) == null)
                    {
                        result.Add(group);
                    }
                }
            }

            return result.Where(x => x.Cells.Any(c => c.Status == CellStatus.Empty)).ToList();
        }
    }
}