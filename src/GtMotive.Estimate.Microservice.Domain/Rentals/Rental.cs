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
            DateTime dueDateUtc,
            DateTime? endedAtUtc)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerId = customerId;
            StartedAtUtc = startedAtUtc;
            DueDateUtc = dueDateUtc;
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
        /// Gets the planned return date, in UTC.
        /// </summary>
        public DateTime DueDateUtc { get; }

        /// <summary>
        /// Gets the moment the rental ended, in UTC, or <c>null</c> when it is still open.
        /// </summary>
        public DateTime? EndedAtUtc { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is still open.
        /// </summary>
        public bool IsActive => EndedAtUtc is null;

        /// <summary>
        /// Gets the planned rental duration in whole days (rounded half-up) from start to the due date.
        /// </summary>
        public int PlannedDays => RoundDays(DueDateUtc - StartedAtUtc);

        /// <summary>
        /// Gets the actual rental duration in whole days (rounded half-up), or <c>null</c> while still open.
        /// </summary>
        public int? ActualDays
        {
            get
            {
                if (EndedAtUtc is { } endedAtUtc)
                {
                    return RoundDays(endedAtUtc - StartedAtUtc);
                }

                return null;
            }
        }

        /// <summary>
        /// Starts a new open rental.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <param name="vehicleId">The rented vehicle identifier.</param>
        /// <param name="customerId">The renting customer identifier.</param>
        /// <param name="startedAtUtc">The moment the rental starts, in UTC.</param>
        /// <param name="dueDateUtc">The planned return date, in UTC.</param>
        /// <returns>A new open <see cref="Rental"/>.</returns>
        public static Rental Start(RentalId id, VehicleId vehicleId, CustomerId customerId, DateTime startedAtUtc, DateTime dueDateUtc)
        {
            if (dueDateUtc <= startedAtUtc)
            {
                throw new DomainException("The planned return date must be after the rental start.");
            }

            return new Rental(id, vehicleId, customerId, startedAtUtc, dueDateUtc, null);
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

            if (endedAtUtc < StartedAtUtc)
            {
                throw new DomainException("The return date cannot be before the rental start.");
            }

            EndedAtUtc = endedAtUtc;
        }

        private static int RoundDays(TimeSpan span)
        {
            return (int)Math.Round(span.TotalDays, MidpointRounding.AwayFromZero);
        }
    }
}
