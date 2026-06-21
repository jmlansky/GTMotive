using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// The created rental.
    /// </summary>
    public sealed class RentalResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalResponse"/> class.
        /// </summary>
        /// <param name="output">The rent vehicle use case output.</param>
        public RentalResponse(RentVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            RentalId = output.RentalId;
            VehicleId = output.VehicleId;
            CustomerId = output.CustomerId;
            StartedAtUtc = output.StartedAtUtc;
            DueDateUtc = output.DueDateUtc;
            PlannedDays = output.PlannedDays;
            VehicleStatus = output.VehicleStatus;
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
        /// Gets the planned rental duration in whole days.
        /// </summary>
        [Required]
        public int PlannedDays { get; }

        /// <summary>
        /// Gets the resulting vehicle status.
        /// </summary>
        [Required]
        public string VehicleStatus { get; }
    }
}
