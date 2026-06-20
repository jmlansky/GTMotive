using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// A single available vehicle in the response.
    /// </summary>
    public sealed class AvailableVehicleModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableVehicleModel"/> class.
        /// </summary>
        /// <param name="item">The available vehicle item.</param>
        public AvailableVehicleModel(AvailableVehicleItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            VehicleId = item.VehicleId;
            Brand = item.Brand;
            Model = item.Model;
            LicensePlate = item.LicensePlate;
            ManufactureDate = item.ManufactureDate;
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
        /// Gets the vehicle manufacture date.
        /// </summary>
        [Required]
        public DateTime ManufactureDate { get; }
    }
}
