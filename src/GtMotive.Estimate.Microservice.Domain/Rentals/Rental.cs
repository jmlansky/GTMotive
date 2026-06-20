using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Rentals
{
    /// <summary>
    /// Aggregate root representing a vehicle rental.
    /// </summary>
    public sealed class Rental
    {
        private Rental(
            RentalId id,
            VehicleId vehicleId,
            CustomerId customerId,
            DateTime startedAtUtc,
            DateTime? endedAtUtc)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerId = customerId;
            StartedAtUtc = startedAtUtc;
            EndedAtUtc = endedAtUtc;
        }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public RentalId Id { get; }

        /// <summary>
        /// Gets the identifier of the rented vehicle.
        /// </summary>
        public VehicleId VehicleId { get; }

        /// <summary>
        /// Gets the identifier of the customer that rented the vehicle.
        /// </summary>
        public CustomerId CustomerId { get; }

        /// <summary>
        /// Gets the moment the rental started, in UTC.
        /// </summary>
        public DateTime StartedAtUtc { get; }

        /// <summary>
        /// Gets the moment the rental ended, in UTC, or <c>null</c> when it is still open.
        /// </summary>
        public DateTime? EndedAtUtc { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is still open.
        /// </summary>
        public bool IsActive => EndedAtUtc is null;

        /// <summary>
        /// Starts a new open rental.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <param name="vehicleId">The rented vehicle identifier.</param>
        /// <param name="customerId">The renting customer identifier.</param>
        /// <param name="startedAtUtc">The moment the rental starts, in UTC.</param>
        /// <returns>A new open <see cref="Rental"/>.</returns>
        public static Rental Start(RentalId id, VehicleId vehicleId, CustomerId customerId, DateTime startedAtUtc)
        {
            return new Rental(id, vehicleId, customerId, startedAtUtc, null);
        }

        /// <summary>
        /// Reconstitutes a rental from persistence.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <param name="vehicleId">The rented vehicle identifier.</param>
        /// <param name="customerId">The renting customer identifier.</param>
        /// <param name="startedAtUtc">The moment the rental started, in UTC.</param>
        /// <param name="endedAtUtc">The moment the rental ended, in UTC, or <c>null</c> when open.</param>
        /// <returns>The reconstituted <see cref="Rental"/>.</returns>
        public static Rental Rehydrate(RentalId id, VehicleId vehicleId, CustomerId customerId, DateTime startedAtUtc, DateTime? endedAtUtc)
        {
            return new Rental(id, vehicleId, customerId, startedAtUtc, endedAtUtc);
        }

        /// <summary>
        /// Closes the rental.
        /// </summary>
        /// <param name="endedAtUtc">The moment the rental ends, in UTC.</param>
        public void Close(DateTime endedAtUtc)
        {
            if (!IsActive)
            {
                throw new DomainException("The rental is already closed.");
            }

            EndedAtUtc = endedAtUtc;
        }
    }
}
