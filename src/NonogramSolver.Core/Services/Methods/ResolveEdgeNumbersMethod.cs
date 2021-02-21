using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    /// <summary>
    /// Method to fill edge numbers. Edge numbers are numbers that have one (or more) starting (ending) filled cells
    ///     and all previous (next) cells are resolved
    /// </summary>
    /// <remarks>
    /// I.e. 2 2 |O X _ _ _ X O| => 2 2 |O X X O X X O|
    /// </remarks>
    public class ResolveEdgeNumbersMethod : MethodBase, IGroupMethod
    {
        public ResolveEdgeNumbersMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void Execute(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                if (line.IsResolved())
                {
                    continue;
                }

                var firstNumber = line.Numbers.FirstOrDefault();

                if (firstNumber != null && !firstNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line.Cells, firstNumber, false);

                    continue;
                }

                var lastNumber = line.Numbers.LastOrDefault();
                
                if (lastNumber != null && !lastNumber.IsResolved)
                {
                    CheckAndFillEdgeNumbers(line.Cells, lastNumber, true);
                }
            }
        }
        
        private void CheckAndFillEdgeNumbers(List<Cell> cells, LineNumber edgeNumber, bool fromTheEnd)
        {
            if (fromTheEnd)
            {
                cells.Reverse();
            }

            for (var i = 0; i < cells.Count - 1; i++)
            {
                if (cells[i].Status == CellStatus.Empty)
                {
                    break;
                }

                if (cells[i].Status == CellStatus.Crossed)
                {
                    continue;
                }

                CellsService.FillNumber(cells, edgeNumber, i);

                break;
            }

            if (fromTheEnd)
            {
                cells.Reverse();
            }
        }

        public void ProcessGroup(Group group, LineNumber number)
        {
            CheckAndFillEdgeNumbers(group.Cells, number, true);
            CheckAndFillEdgeNumbers(group.Cells, number, false);
        }
    }
}