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
    public sealed class ReturnVehicleInput(VehicleId vehicleId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;
    }
}
