using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NonogramSolver.Tests.DependencyInjection;

namespace NonogramSolver.Tests.Modules
{
    public class ServiceTestModuleBase: Module
    {
        protected IConfiguration Configuration;

        public override void Load(IServiceCollection collection, IConfiguration configuration)
        {
            Configuration = configuration;
            RegisterDependencies(collection);
        }

        protected virtual void RegisterDependencies(IServiceCollection collection)
        {
            
        }
    }
}