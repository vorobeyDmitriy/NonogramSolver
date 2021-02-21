using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface IGroupMethod
    {
        void ProcessGroup(Group group, LineNumber number);
    }
}