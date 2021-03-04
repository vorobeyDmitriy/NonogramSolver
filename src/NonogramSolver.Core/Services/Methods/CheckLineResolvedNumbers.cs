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
    public class CheckLineResolvedNumbers : MethodBase, IIterationMethod, IGroupMethod
    {
        public CheckLineResolvedNumbers(ICellsService cellsService)
            : base(cellsService) { }

        public override void ProcessPuzzle(Puzzle puzzle)
        {
            var lines = puzzle.GetLines().Where(x => !x.IsResolved());

            foreach (var line in lines)
            {
                ProcessLine(line);
            }
        }

        public void ProcessLine(Line line)
        {
            ProcessCells(line.Cells, line.Numbers);
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

        private void ProcessCells(List<Cell> cells, List<LineNumber> numbers, bool withResolve = true)
        {
            CheckAndResolveNumbers(cells, numbers, false, withResolve);
            CheckAndResolveNumbers(cells, numbers, true, withResolve);
        }

        private void CheckAndResolveNumbers(List<Cell> cells, List<LineNumber> numbers, bool fromTheEnd,
            bool withResolve = true)
        {
            if (fromTheEnd)
            {
                cells.Reverse();
                numbers.Reverse();
            }

            var numberIndex = 0;

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

                if (cells[i].Status == CellStatus.Filled)
                {
                    var length = GetLength(cells, i);
                    var number = numbers.Skip(numberIndex).FirstOrDefault();

                    if (number.Number == length)
                    {
                        CellsService.FillNumber(cells, number, i, withResolve);
                        numberIndex++;
                    }
                    else
                    {
                        break;
                    }

                    i += length - 1;
                }
            }

            if (fromTheEnd)
            {
                cells.Reverse();
                numbers.Reverse();
            }
        }

        private static int GetLength(IReadOnlyList<Cell> cells, int startIndex)
        {
            var length = 0;

            for (var j = startIndex; j < cells.Count - 1; j++)
            {
                if (cells[j].Status == CellStatus.Filled)
                {
                    length++;
                }
                else
                {
                    break;
                }
            }

            return length;
        }
    }
}