using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// A single available vehicle returned by the list use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AvailableVehicleItem"/> class.
    /// </remarks>
    /// <param name="vehicleId">The vehicle identifier.</param>
    /// <param name="brand">The vehicle brand.</param>
    /// <param name="model">The vehicle model.</param>
    /// <param name="licensePlate">The vehicle license plate.</param>
    /// <param name="manufactureDate">The vehicle manufacture date.</param>
    public sealed class AvailableVehicleItem(Guid vehicleId, string brand, string model, string licensePlate, DateTime manufactureDate)
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; } = brand;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; } = model;

        /// <summary>
        /// Gets the vehicle license plate.
        /// </summary>
        public string LicensePlate { get; } = licensePlate;

        /// <summary>
        /// Gets the vehicle manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
