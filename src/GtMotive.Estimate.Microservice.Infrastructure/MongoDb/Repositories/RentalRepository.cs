using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public sealed class RentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<RentalDocument> _rentals;

        public RentalRepository(MongoService mongoService, IOptions<MongoDbSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(settings);

            var database = mongoService.MongoClient.GetDatabase(settings.Value.MongoDbDatabaseName);
            _rentals = database.GetCollection<RentalDocument>("rentals");
        }

        public Task Add(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            var document = RentalDocument.FromDomain(rental);
            return _rentals.InsertOneAsync(document);
        }

        public Task<bool> ExistsActiveByCustomer(CustomerId customerId)
        {
            var customerGuid = customerId.ToGuid();

            return _rentals
                .Find(document => document.CustomerId == customerGuid && document.EndedAtUtc == null)
                .AnyAsync();
        }
    }
}
