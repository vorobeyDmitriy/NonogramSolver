using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NonogramSolver.Tests.DependencyInjection
{
    /// <summary>
    ///     Represents a set of components and related functionality
    ///     packaged together.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        ///     Apply the module to the component registry.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="configuration"></param>
        void Load(IServiceCollection collection, IConfiguration configuration);
    }
}