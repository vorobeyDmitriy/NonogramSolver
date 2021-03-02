using System.Collections.Generic;
using System.Linq;
using NonogramSolver.Core.Enumerations;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    public class CheckLineResolvedNumbers : MethodBase,IIterationMethod
    {
        public CheckLineResolvedNumbers(ICellsService cellsService)
            : base(cellsService) { }
        
        public void ProcessLine(Line line)
        {
            CheckAndResolveNumbers(line, false);
            CheckAndResolveNumbers(line, true);
        }

        
        //todo: merge with ResolveEdgeNumbersMethod
        private void CheckAndResolveNumbers(Line line, bool fromTheEnd)
        {
            if (fromTheEnd)
            {
                line.Cells.Reverse();
                line.Numbers.Reverse();
            }
            
            var numberIndex = 0;
            
            for (var i = 0; i < line.Cells.Count - 1; i++)
            {
                if (line.Cells[i].Status == CellStatus.Empty)
                {
                    break;
                }

                if (line.Cells[i].Status == CellStatus.Crossed)
                {
                    continue;
                }
                
                if (line.Cells[i].Status == CellStatus.Filled)
                {
                    var length = GetLength(line.Cells, i);
                    var number = line.Numbers.Skip(numberIndex).FirstOrDefault();

                    if (number.Number == length)
                    {
                        CellsService.FillNumber(line.Cells, number, i);
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
                line.Cells.Reverse();
                line.Numbers.Reverse();
            }
        }

        private int GetLength(IReadOnlyList<Cell> cells, int startIndex)
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
        
        public override void ProcessPuzzle(Puzzle puzzle)
        {
            throw new System.NotImplementedException();
        }
    }
}