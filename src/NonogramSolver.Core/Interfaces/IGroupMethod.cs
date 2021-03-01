using System.Collections.Generic;
using NonogramSolver.Core.Models;

namespace NonogramSolver.Core.Interfaces
{
    public interface IGroupMethod
    {
        void ProcessGroup(Group group, List<LineNumber> numbers);
    }
}