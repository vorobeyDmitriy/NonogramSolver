using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface IIterationMethod
    {
        public void CompleteLine(Line line);
    }
}