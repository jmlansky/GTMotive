using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using GtMotive.Estimate.Microservice.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Storage engine selection lives in one place. Swap AddInMemoryPersistence for a future
            // AddMongoPersistence to move to MongoDB without touching the rest of the application.
            services.AddInMemoryPersistence();

            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            if (isDevelopment)
            {
                services.AddScoped<ITelemetry, NoOpTelemetry>();
                return new InfrastructureBuilder(services);
            }

            services.AddScoped<ITelemetry, AppTelemetry>();
            return new InfrastructureBuilder(services);
        }

        private sealed class InfrastructureBuilder(IServiceCollection services) : IInfrastructureBuilder
        {
            public IServiceCollection Services { get; } = services;
        }
    }
}
