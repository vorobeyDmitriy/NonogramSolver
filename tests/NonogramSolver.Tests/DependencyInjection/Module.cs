using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NonogramSolver.Tests.DependencyInjection
{
    /// <summary>
    ///     Represents a set of components and related functionality
    ///     packaged together.
    /// </summary>
    public abstract class Module : IModule
    {
        protected const string TestEnvName = "test";

        /// <summary>
        ///     Apply the module to the component registry.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="configuration"></param>
        public abstract void Load(IServiceCollection collection, IConfiguration configuration);

        protected bool IsTestConfiguration(IConfiguration configuration)
        {
            var currentEnvName = configuration["Environment"] ?? string.Empty;
            return currentEnvName.Equals(TestEnvName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}