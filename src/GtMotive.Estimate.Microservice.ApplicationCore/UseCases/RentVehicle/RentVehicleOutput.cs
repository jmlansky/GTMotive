using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output message for the rent vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
    /// </remarks>
    /// <param name="rentalId">The rental identifier.</param>
    /// <param name="vehicleId">The rented vehicle identifier.</param>
    /// <param name="customerId">The renting customer identifier.</param>
    /// <param name="startedAtUtc">The moment the rental started, in UTC.</param>
    /// <param name="dueDateUtc">The planned return date, in UTC.</param>
    /// <param name="plannedDays">The planned rental duration in whole days.</param>
    /// <param name="vehicleStatus">The resulting vehicle status.</param>
    public sealed class RentVehicleOutput(
        Guid rentalId,
        Guid vehicleId,
        Guid customerId,
        DateTime startedAtUtc,
        DateTime dueDateUtc,
        int plannedDays,
        string vehicleStatus) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets the rented vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the renting customer identifier.
        /// </summary>
        public Guid CustomerId { get; } = customerId;

        /// <summary>
        /// Gets the moment the rental started, in UTC.
        /// </summary>
        public DateTime StartedAtUtc { get; } = startedAtUtc;

        /// <summary>
        /// Gets the planned return date, in UTC.
        /// </summary>
        public DateTime DueDateUtc { get; } = dueDateUtc;

        /// <summary>
        /// Gets the planned rental duration in whole days.
        /// </summary>
        public int PlannedDays { get; } = plannedDays;

        /// <summary>
        /// Gets the resulting vehicle status.
        /// </summary>
        public string VehicleStatus { get; } = vehicleStatus;
    }
}
