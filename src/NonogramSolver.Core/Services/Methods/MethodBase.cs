using System.Linq;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Services.Methods
{
    public abstract class MethodBase : IMethod
    {
        protected readonly ICellsService CellsService;
        
        protected MethodBase(ICellsService cellsService)
        {
            CellsService = cellsService;
        }

        public void ProcessPuzzle(Puzzle puzzle)
        {
            var lines = puzzle.GetLines().Where(x => !x.IsResolved());
            
            foreach (var line in lines)
            {
                ProcessLine(line);
            }
        }

        public abstract void ProcessLine(Line line);
    }
}