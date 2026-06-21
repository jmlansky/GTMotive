using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input message for the return vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
    /// </remarks>
    /// <param name="vehicleId">The vehicle being returned.</param>
    /// <param name="returnedAtUtc">The requested return date in UTC, or <c>null</c> to return now.</param>
    public sealed class ReturnVehicleInput(VehicleId vehicleId, DateTime? returnedAtUtc) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the requested return date in UTC, or <c>null</c> to return now.
        /// </summary>
        public DateTime? ReturnedAtUtc { get; } = returnedAtUtc;
    }
}
