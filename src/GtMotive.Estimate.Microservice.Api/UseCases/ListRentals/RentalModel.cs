using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListRentals
{
    /// <summary>
    /// A single rental in the response.
    /// </summary>
    public sealed class RentalModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalModel"/> class.
        /// </summary>
        /// <param name="item">The rental item.</param>
        public RentalModel(RentalItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            RentalId = item.RentalId;
            VehicleId = item.VehicleId;
            CustomerId = item.CustomerId;
            StartedAtUtc = item.StartedAtUtc;
            DueDateUtc = item.DueDateUtc;
            EndedAtUtc = item.EndedAtUtc;
            PlannedDays = item.PlannedDays;
            ActualDays = item.ActualDays;
            Status = item.Status;
        }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        [Required]
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the rented vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the renting customer identifier.
        /// </summary>
        [Required]
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the moment the rental started, in UTC.
        /// </summary>
        [Required]
        public DateTime StartedAtUtc { get; }

        /// <summary>
        /// Gets the planned return date, in UTC.
        /// </summary>
        [Required]
        public DateTime DueDateUtc { get; }

        /// <summary>
        /// Gets the moment the rental ended, in UTC, or <c>null</c> when still open.
        /// </summary>
        public DateTime? EndedAtUtc { get; }

        /// <summary>
        /// Gets the planned rental duration in whole days.
        /// </summary>
        [Required]
        public int PlannedDays { get; }

        /// <summary>
        /// Gets the actual rental duration in whole days, or <c>null</c> when still open.
        /// </summary>
        public int? ActualDays { get; }

        /// <summary>
        /// Gets the rental status.
        /// </summary>
        [Required]
        public string Status { get; }
    }
}
