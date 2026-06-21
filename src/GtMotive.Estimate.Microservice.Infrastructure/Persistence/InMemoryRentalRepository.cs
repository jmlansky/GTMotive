using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    public sealed class InMemoryRentalRepository : IRentalRepository
    {
        private readonly ConcurrentDictionary<Guid, Rental> _rentals = new();

        public Task Add(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            _ = _rentals.TryAdd(rental.Id.ToGuid(), rental);

            return Task.CompletedTask;
        }

        public Task Update(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            _rentals[rental.Id.ToGuid()] = rental;

            return Task.CompletedTask;
        }

        public Task<Rental> GetActiveByVehicle(VehicleId vehicleId)
        {
            var vehicleGuid = vehicleId.ToGuid();
            var rental = _rentals.Values.FirstOrDefault(stored => stored.IsActive && stored.VehicleId.ToGuid() == vehicleGuid);

            return Task.FromResult(rental);
        }

        public Task<bool> ExistsActiveByCustomer(CustomerId customerId)
        {
            var customerGuid = customerId.ToGuid();
            var exists = _rentals.Values.Any(rental => rental.IsActive && rental.CustomerId.ToGuid() == customerGuid);

            return Task.FromResult(exists);
        }
    }
}
