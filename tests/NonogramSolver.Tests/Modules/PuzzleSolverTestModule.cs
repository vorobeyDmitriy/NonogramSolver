using Microsoft.Extensions.DependencyInjection;
using NonogramSolver.Core.Interfaces;
using NonogramSolver.Core.Services;
using NonogramSolver.Core.Services.Methods;

namespace NonogramSolver.Tests.Modules
{
    public class PuzzleSolverTestModule: ServiceTestModuleBase
    {
        protected override void RegisterDependencies(IServiceCollection collection)
        {
            collection.AddSingleton<IMethod, ResolveCompletedLinesMethod>();
            collection.AddSingleton<IMethod, PartiallyFillNumberMethod>();
            collection.AddSingleton<IMethod, PartiallyFillGroupsMethod>();
            collection.AddSingleton<IGroupMethod, PartiallyFillNumberMethod>();
            collection.AddSingleton<IIterationMethod, ResolvedEdgeNumbersMethod>();
            collection.AddSingleton<IIterationMethod, ResolveCompletedLinesMethod>();
            collection.AddSingleton<IIterationMethod, PartiallyFillNumberMethod>();
            collection.AddSingleton<ICellsService, CellsService>();
            collection.AddSingleton<IPuzzleSolver, PuzzleSolver>();
            base.RegisterDependencies(collection);
        }
    }
}