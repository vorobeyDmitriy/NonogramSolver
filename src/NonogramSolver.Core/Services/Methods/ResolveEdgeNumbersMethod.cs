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
    public class ResolveEdgeNumbersMethod : MethodBase, IGroupMethod, IIterationMethod
    {
        public ResolveEdgeNumbersMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void ProcessPuzzle(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                ProcessLine(line);
            }
        }
        
        public void ProcessLine(Line line)
        {
            if (line.IsResolved())
            {
                return;
            }

            ProcessCells(line.Cells, line.Numbers, true);
        }
        
        public void ProcessGroup(Group group, List<LineNumber> numbers)
        {
            var firstFilledCell = group.Cells.FindIndex(x => x.Status == CellStatus.Filled);
            var lastFilledCell = group.Cells.FindLastIndex(x => x.Status == CellStatus.Filled);

            if (numbers.Count == 1 && lastFilledCell - firstFilledCell + 1 > numbers.FirstOrDefault()?.Number)
            {
                return;
            }

            ProcessCells(group.Cells, numbers, false);
        }

        private void ProcessCells(List<Cell> cells, List<LineNumber> numbers, bool withResolve)
        {
            var firstNumber = numbers.FirstOrDefault();
            
            if (firstNumber != null && !firstNumber.IsResolved)
            {
                CheckAndFillEdgeNumbers(cells, firstNumber, false, withResolve);
            }

            var lastNumber = numbers.LastOrDefault();
                
            if (lastNumber != null && !lastNumber.IsResolved)
            {
                CheckAndFillEdgeNumbers(cells, lastNumber, true, withResolve);
            }
        }
        
        private void CheckAndFillEdgeNumbers(List<Cell> cells, LineNumber edgeNumber, bool fromTheEnd, bool withResolve,
            int startIndex = 0)
        {
            if (fromTheEnd)
            {
                cells.Reverse();
            }

            for (var i = startIndex; i < cells.Count - 1; i++)
            {
                if (cells[i].Status == CellStatus.Empty)
                {
                    break;
                }

                if (cells[i].Status == CellStatus.Crossed)
                {
                    continue;
                }

                CellsService.FillNumber(cells, edgeNumber, i, withResolve);

                break;
            }

            if (fromTheEnd)
            {
                cells.Reverse();
            }
        }
    }
}