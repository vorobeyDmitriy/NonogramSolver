using Microsoft.Extensions.DependencyInjection;
using NonogramSolver.Core;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Services;
using NonogramSolver.Core.Services.Methods;

namespace NonogramSolver.Tests.Modules
{
    public class ResolveCompletedTrivialLinesMethodTestModule : ServiceTestModuleBase
    {
        protected override void RegisterDependencies(IServiceCollection collection)
        {
            collection.AddSingleton<IMethod, ResolveTrivialLinesMethod>();
            collection.AddSingleton<ICellsService, CellsService>();
            base.RegisterDependencies(collection);
        }
    }
}