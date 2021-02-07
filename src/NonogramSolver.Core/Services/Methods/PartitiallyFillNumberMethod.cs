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
    public class PartiallyFillNumberMethod : MethodBase
    {
        public PartiallyFillNumberMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void Execute(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                if (line.IsResolved())
                {
                    continue;
                }

                var numbersCount = line.Numbers.Count;

                for (var i = 0; i < numbersCount; i++)
                {
                    var leftPosition = line.Numbers.Take(i + 1).Sum(x => x.Number) + i - 1;

                    line.Numbers.Reverse();

                    var occupiedSpaceFromRight =
                        line.Numbers.Take(numbersCount - i).Sum(x => x.Number) + numbersCount - 2 - i;

                    line.Numbers.Reverse();

                    var rightPosition = line.Cells.Count - 1 - occupiedSpaceFromRight;

                    if (rightPosition > leftPosition)
                    {
                        continue;
                    }

                    for (var j = rightPosition; j <= leftPosition; j++)
                    {
                        line.Cells[j].Fill();
                    }
                }
            }
        }
    }
}