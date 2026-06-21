using System;
using GtMotive.Estimate.Microservice.Domain.Rentals;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals
{
    /// <summary>
    /// A single rental returned by the list rentals use case.
    /// </summary>
    public sealed class RentalItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalItem"/> class.
        /// </summary>
        /// <param name="rental">The rental to project.</param>
        public RentalItem(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            RentalId = rental.Id.ToGuid();
            VehicleId = rental.VehicleId.ToGuid();
            CustomerId = rental.CustomerId.ToGuid();
            StartedAtUtc = rental.StartedAtUtc;
            DueDateUtc = rental.DueDateUtc;
            EndedAtUtc = rental.EndedAtUtc;
            PlannedDays = rental.PlannedDays;
            ActualDays = rental.ActualDays;
            Status = rental.IsActive ? "Active" : "Closed";
        }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the rented vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the renting customer identifier.
        /// </summary>
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the moment the rental started, in UTC.
        /// </summary>
        public DateTime StartedAtUtc { get; }

        /// <summary>
        /// Gets the planned return date, in UTC.
        /// </summary>
        public DateTime DueDateUtc { get; }

        /// <summary>
        /// Gets the moment the rental ended, in UTC, or <c>null</c> when open.
        /// </summary>
        public DateTime? EndedAtUtc { get; }

        /// <summary>
        /// Gets the planned rental duration in whole days.
        /// </summary>
        public int PlannedDays { get; }

        /// <summary>
        /// Gets the actual rental duration in whole days, or <c>null</c> when open.
        /// </summary>
        public int? ActualDays { get; }

        /// <summary>
        /// Gets the rental status.
        /// </summary>
        public string Status { get; }
    }
}
