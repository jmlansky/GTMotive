using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output message for the return vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
    /// </remarks>
    /// <param name="vehicleId">The returned vehicle identifier.</param>
    /// <param name="rentalId">The closed rental identifier.</param>
    /// <param name="endedAtUtc">The moment the rental was closed, in UTC.</param>
    /// <param name="vehicleStatus">The resulting vehicle status.</param>
    public sealed class ReturnVehicleOutput(
        Guid vehicleId,
        Guid rentalId,
        DateTime endedAtUtc,
        string vehicleStatus) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the returned vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the closed rental identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets the moment the rental was closed, in UTC.
        /// </summary>
        public DateTime EndedAtUtc { get; } = endedAtUtc;

        /// <summary>
        /// Gets the resulting vehicle status.
        /// </summary>
        public string VehicleStatus { get; } = vehicleStatus;
    }
}
