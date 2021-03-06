using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    /// <summary>
    /// Method to fill numbers that have one or more cells with determined position 
    /// </summary>
    /// <remarks>
    /// I.e. 3 |_ _ _ _ _| => 3 |_ _ X _ _|
    /// </remarks>
    public class PartiallyFillNumberMethod : MethodBase, IGroupMethod, IIterationMethod
    {
        public PartiallyFillNumberMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void ProcessLine(Line line)
        {
            ProcessCells(line.Cells, line.Numbers);
        }

        public void ProcessGroup(Group group, List<LineNumber> numbers)
        {
            ProcessCells(group.Cells, numbers);
        }

        private static void ProcessCells(IReadOnlyList<Cell> cells, List<LineNumber> numbers)
        {
            var numbersCount = numbers.Count;

            for (var i = 0; i < numbersCount; i++)
            {
                var leftPosition = numbers.Take(i + 1).Sum(x => x.Number) + i - 1;

                numbers.Reverse();

                var occupiedSpaceFromRight =
                    numbers.Take(numbersCount - i).Sum(x => x.Number) + numbersCount - 2 - i;

                numbers.Reverse();

                var rightPosition = cells.Count - 1 - occupiedSpaceFromRight;

                if (rightPosition > leftPosition)
                {
                    continue;
                }

                for (var j = rightPosition; j <= leftPosition; j++)
                {
                    cells[j].Fill();
                }
            }
        }
    }
}