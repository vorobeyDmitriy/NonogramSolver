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
        
        public abstract void ProcessPuzzle(Puzzle puzzle);
    }
}