using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    public sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly ConcurrentDictionary<Guid, Vehicle> _vehicles = new();

        public Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            _vehicles[vehicle.Id.ToGuid()] = vehicle;

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Vehicle>> ListAvailable()
        {
            var available = _vehicles.Values
                .Where(vehicle => vehicle.Status == VehicleStatus.Available)
                .ToList();

            return Task.FromResult<IReadOnlyCollection<Vehicle>>(available);
        }
    }
}
