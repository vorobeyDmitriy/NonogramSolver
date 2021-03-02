using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    /// <summary>
    /// Method to resolve lines that was already resolved but not marked as Resolved 
    /// </summary>
    /// <remarks>
    /// I.e. 2 1 |X X _ X _| => |X X O X O| and numbers marked as resolved
    /// </remarks>
    public class ResolveCompletedLinesMethod : MethodBase, IGroupMethod, IIterationMethod
    {
        public ResolveCompletedLinesMethod(ICellsService cellsService)
            : base(cellsService) { }
        
        public override void Execute(Puzzle puzzle)
        {
            var lines = puzzle.GetLines();
            foreach (var line in lines.Where(x => !x.IsResolved()))
            {
                ResolveCells(line.Cells, line.Numbers);
            }
        }

        private void ResolveCells(IReadOnlyCollection<Cell> cells, IReadOnlyCollection<LineNumber> numbers)
        {
            var filledCellsCount = cells.Count(x => x.Status == CellStatus.Filled);
            var sumOfNumbers = numbers.Sum(x => x.Number);

            if (sumOfNumbers != filledCellsCount)
            {
                return;
            }

            CellsService.CrossCells(cells.Where(x => x.Status == CellStatus.Empty));
            CellsService.ResolveNumbers(numbers);
        }

        public void ProcessGroup(Group group, List<LineNumber> numbers)
        {
            var filledCellsCount = group.Cells.Count(x => x.Status == CellStatus.Filled);
            var sumOfNumbers = numbers.Sum(x => x.Number);

            if (sumOfNumbers != filledCellsCount)
            {
                return;
            }

            CellsService.CrossCells(group.Cells.Where(x => x.Status == CellStatus.Empty));
            CellsService.ResolveNumbers(numbers);
        }

        public void CompleteLine(Line line)
        {
            var filledCellsCount = line.Cells.Count(x => x.Status == CellStatus.Filled);
            var sumOfNumbers = line.Numbers.Sum(x => x.Number);

            if (sumOfNumbers != filledCellsCount)
            {
                return;
            }

            CellsService.CrossCells(line.Cells.Where(x => x.Status == CellStatus.Empty));
            CellsService.ResolveNumbers(line.Numbers);
        }
    }
}