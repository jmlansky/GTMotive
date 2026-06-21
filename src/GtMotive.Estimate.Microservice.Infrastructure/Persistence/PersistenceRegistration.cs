using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// Single place where the storage engine is selected. Switching the in-memory store for a
    /// database-backed one later only requires adding an equivalent registration method (the new
    /// repositories behind the same ports) and changing the single call in InfrastructureConfiguration.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class PersistenceRegistration
    {
        /// <summary>
        /// Registers the in-memory storage engine (current default).
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddSingleton<IRentalRepository, InMemoryRentalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
