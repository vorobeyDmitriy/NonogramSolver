using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    /// <summary>
    /// Method to fill trivial lines. Trivial lines are lines where sum of numbers with spaces equals cells count
    /// </summary>
    /// <remarks>
    /// I.e. 4 |_ _ _ _| => 4 |X X X X|
    /// </remarks>
    public class ResolveTrivialLinesMethod : MethodBase
    {
        public ResolveTrivialLinesMethod(ICellsService cellsService)
            : base(cellsService) { }

        public override void ProcessPuzzle(Puzzle puzzle)
        {
            foreach (var line in puzzle.GetLines())
            {
                if (line.GetLengthWithSpaces() != line.Cells.Count)
                {
                    continue;
                }

                var startIndex = 0;

                foreach (var number in line.Numbers)
                {
                    var cells = line.Cells.Skip(startIndex).Take(number.Number);
                    CellsService.FillCells(cells);
                    startIndex += number.Number + 1;
                }
                
                CellsService.CrossCells(line.Cells.Where(x=>x.Status!=CellStatus.Filled));
                CellsService.ResolveNumbers(line.Numbers);
            }
        }
    }
}