using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// The result of returning a vehicle.
    /// </summary>
    public sealed class ReturnConfirmationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnConfirmationResponse"/> class.
        /// </summary>
        /// <param name="output">The return vehicle use case output.</param>
        public ReturnConfirmationResponse(ReturnVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            VehicleId = output.VehicleId;
            RentalId = output.RentalId;
            EndedAtUtc = output.EndedAtUtc;
            ActualDays = output.ActualDays;
            VehicleStatus = output.VehicleStatus;
        }

        /// <summary>
        /// Gets the returned vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the closed rental identifier.
        /// </summary>
        [Required]
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the moment the rental was closed, in UTC.
        /// </summary>
        [Required]
        public DateTime EndedAtUtc { get; }

        /// <summary>
        /// Gets the actual rental duration in whole days.
        /// </summary>
        public int? ActualDays { get; }

        /// <summary>
        /// Gets the resulting vehicle status.
        /// </summary>
        [Required]
        public string VehicleStatus { get; }
    }
}
