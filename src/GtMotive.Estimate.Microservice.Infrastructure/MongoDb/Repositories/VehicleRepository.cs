using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public sealed class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<VehicleDocument> _vehicles;

        public VehicleRepository(MongoService mongoService, IOptions<MongoDbSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(settings);

            var database = mongoService.MongoClient.GetDatabase(settings.Value.MongoDbDatabaseName);
            _vehicles = database.GetCollection<VehicleDocument>("vehicles");
        }

        public Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var document = VehicleDocument.FromDomain(vehicle);
            return _vehicles.InsertOneAsync(document);
        }

        public Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var document = VehicleDocument.FromDomain(vehicle);
            return _vehicles.ReplaceOneAsync(stored => stored.Id == document.Id, document);
        }

        public async Task<Vehicle> GetById(VehicleId id)
        {
            var vehicleId = id.ToGuid();
            var document = await _vehicles
                .Find(stored => stored.Id == vehicleId)
                .FirstOrDefaultAsync();

            return document?.ToDomain();
        }

        public async Task<IReadOnlyCollection<Vehicle>> ListAvailable()
        {
            var documents = await _vehicles
                .Find(document => document.Status == VehicleStatus.Available.ToString())
                .ToListAsync();

            return documents.ConvertAll(document => document.ToDomain());
        }

        public Task<bool> ExistsByLicensePlate(string licensePlate)
        {
            return _vehicles
                .Find(document => document.LicensePlate == licensePlate)
                .AnyAsync();
        }
    }
}
