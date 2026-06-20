using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    public sealed class VehicleDocument
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string Status { get; set; }

        public static VehicleDocument FromDomain(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            return new VehicleDocument
            {
                Id = vehicle.Id.ToGuid(),
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                LicensePlate = vehicle.LicensePlate,
                ManufactureDate = vehicle.ManufactureDate.Value,
                Status = vehicle.Status.ToString(),
            };
        }

        public Vehicle ToDomain()
        {
            return Vehicle.Rehydrate(
                new VehicleId(Id),
                Brand,
                Model,
                LicensePlate,
                new ManufactureDate(ManufactureDate),
                Enum.Parse<VehicleStatus>(Status));
        }
    }
}
