using System;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input message for the rent vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
    /// </remarks>
    /// <param name="vehicleId">The vehicle to rent.</param>
    /// <param name="customerId">The customer renting the vehicle.</param>
    /// <param name="dueDateUtc">The planned return date, in UTC.</param>
    public sealed class RentVehicleInput(VehicleId vehicleId, CustomerId customerId, DateTime dueDateUtc) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public CustomerId CustomerId { get; } = customerId;

        /// <summary>
        /// Gets the planned return date, in UTC.
        /// </summary>
        public DateTime DueDateUtc { get; } = dueDateUtc;
    }
}
