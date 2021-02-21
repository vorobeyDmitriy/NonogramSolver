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
                var variants = GetLineVariants(groups.Count, i, numbers);
                result.AddRange(variants);
            }

            return result; //.Where(x=>x.IsValid(numbers.Select(c=>c.Number).ToList(), groups)).ToList();
        }

        private List<LineVariant> GetLineVariants(int groupsCount, int groupIndex, List<LineNumber> numbers, int numberOffset = 0)
        {
            var lineVariants = new List<LineVariant>();
            if (groupIndex >= groupsCount)
            {
                return new List<LineVariant>();
            }
            
            for (int j = 0; j < numbers.Count; j++)
            {
                var result = new List<GroupVariant>();
                var groupVariant = new GroupVariant
                {
                    GroupIndex = groupIndex,
                    NumbersIndexes = numbers.Take(numbers.Count-j).Select((_, i) => i+numberOffset).ToList()
                };

                if (j != 0)
                {
                    var nextGroupIndex = groupIndex + 1;
                    var otherVariants = GetLineVariants(groupsCount, nextGroupIndex, numbers.TakeLast(j).ToList(), numbers.Count-j);

                    if (otherVariants.Any())
                    {
                        result.AddRange(otherVariants.FirstOrDefault().Variants);

                        var variantsToAdd = otherVariants.Skip(1).ToList();
                        
                        foreach (var variant in variantsToAdd)
                        {
                            variant.Variants.Add(groupVariant);
                        }
                        
                        lineVariants.AddRange(variantsToAdd.Skip(1).Select(variant => new LineVariant {Variants = variant.Variants}));
                    }
                    else
                    {
                        continue;
                    }
                }
                
                result.Add(groupVariant);

                var lineVariant = new LineVariant
                {
                    Variants = result
                };
                lineVariants.Add(lineVariant);
            }

            return lineVariants;
        }
        
        private List<LineNumber> GetGroupNumbers(Group group, List<LineNumber> numbers)
        {
            while (true)
            {
                if (GroupCanContainsNumbers(group, numbers))
                {
                    return numbers.Select(x => x).ToList();
                }

                numbers = numbers.Take(numbers.Count - 1).ToList();
            }
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