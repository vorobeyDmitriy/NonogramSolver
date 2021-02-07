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

                var lineVariants = GetVariants(groups, unresolvedNumbers)
                    .Where(x=>x.IsValid(unresolvedNumbers.Count))
                    .ToList();
            }
        }

        private List<LineVariant> GetVariants(List<Group> groups, List<LineNumber> numbers)
        {
            return groups.Select((_, i) => new LineVariant
            {
                Variants = GetGroupVariants(groups.Skip(i).ToList(), numbers)
            }).ToList();
        }

        private List<GroupVariant> GetGroupVariants(List<Group> groups, List<LineNumber> groupNumbers,
            int groupIndex = 0, int groupNumbersOffset = 0)
        {
            var result = new List<GroupVariant>();
            var group = groups.ElementAtOrDefault(groupIndex);

            if (group == null)
            {
                return null;
            }

            var numbers = GetGroupNumbers(group, groupNumbers);

            result.Add(new GroupVariant
            {
                GroupIndex = groupIndex,
                NumbersIndexes = numbers.Select((_, i) => groupNumbersOffset + i).ToList()
            });

            if (numbers.Count == groupNumbers.Count && groupNumbers.Count > 0)
            {
                return result;
            }

            groupIndex++;

            var otherVariants = GetGroupVariants(groups, groupNumbers.Skip(numbers.Count).ToList(),
                groupIndex, groupNumbersOffset + numbers.Count);

            if (otherVariants == null)
            {
                return result;
            }

            result.AddRange(otherVariants);

            return result;
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