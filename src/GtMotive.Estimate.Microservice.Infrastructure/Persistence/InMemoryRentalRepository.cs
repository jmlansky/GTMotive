using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rentals;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    public sealed class InMemoryRentalRepository : IRentalRepository
    {
        private readonly ConcurrentDictionary<Guid, Rental> _rentals = new();

        public Task Add(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            _rentals[rental.Id.ToGuid()] = rental;

            return Task.CompletedTask;
        }

        public Task<bool> ExistsActiveByCustomer(CustomerId customerId)
        {
            var customerGuid = customerId.ToGuid();
            var exists = _rentals.Values.Any(rental => rental.IsActive && rental.CustomerId.ToGuid() == customerGuid);

            return Task.FromResult(exists);
        }
    }
}
