using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Vehicle registered in the fleet.
    /// </summary>
    public sealed class CreateVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleResponse"/> class.
        /// </summary>
        /// <param name="output">The create vehicle use case output.</param>
        public CreateVehicleResponse(CreateVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            VehicleId = output.VehicleId;
            Brand = output.Brand;
            Model = output.Model;
            LicensePlate = output.LicensePlate;
            ManufactureDate = output.ManufactureDate;
            Status = output.Status;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        [Required]
        public string Brand { get; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        [Required]
        public string Model { get; }

        /// <summary>
        /// Gets the vehicle license plate.
        /// </summary>
        [Required]
        public string LicensePlate { get; }

        /// <summary>
        /// Gets the manufacture date.
        /// </summary>
        [Required]
        public DateTime ManufactureDate { get; }

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        [Required]
        public string Status { get; }
    }
}
