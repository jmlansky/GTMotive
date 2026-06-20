using System;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    public sealed class RentalDocument
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime StartedAtUtc { get; set; }

        public DateTime? EndedAtUtc { get; set; }

        public static RentalDocument FromDomain(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            return new RentalDocument
            {
                Id = rental.Id.ToGuid(),
                VehicleId = rental.VehicleId.ToGuid(),
                CustomerId = rental.CustomerId.ToGuid(),
                StartedAtUtc = rental.StartedAtUtc,
                EndedAtUtc = rental.EndedAtUtc,
            };
        }

        public Rental ToDomain()
        {
            return Rental.Rehydrate(
                new RentalId(Id),
                new VehicleId(VehicleId),
                new CustomerId(CustomerId),
                StartedAtUtc,
                EndedAtUtc);
        }
    }
}
