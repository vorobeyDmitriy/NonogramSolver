using Microsoft.Extensions.DependencyInjection;
using NonogramSolver.Core;
using NonogramSolver.Core.Interfaces;

namespace NonogramSolver.Tests.Modules
{
    public class SolverTestModule : ServiceTestModuleBase
    {
        protected override void RegisterDependencies(IServiceCollection collection)
        {
            collection.AddSingleton<ISolver, Solver>();
            base.RegisterDependencies(collection);
        }
    }
}