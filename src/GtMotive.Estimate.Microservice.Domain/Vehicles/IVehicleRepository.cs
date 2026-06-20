using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Persistence port for the <see cref="Vehicle"/> aggregate root.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a vehicle to the fleet store.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Add(Vehicle vehicle);

        /// <summary>
        /// Updates an existing vehicle in the fleet store.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Update(Vehicle vehicle);

        /// <summary>
        /// Gets a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>The vehicle, or <c>null</c> when it does not exist.</returns>
        Task<Vehicle> GetById(VehicleId id);

        /// <summary>
        /// Lists the vehicles currently available to rent.
        /// </summary>
        /// <returns>The available vehicles.</returns>
        Task<IReadOnlyCollection<Vehicle>> ListAvailable();

        /// <summary>
        /// Determines whether a vehicle with the given license plate already exists.
        /// </summary>
        /// <param name="licensePlate">The license plate to check.</param>
        /// <returns><c>true</c> when a vehicle with that license plate already exists.</returns>
        Task<bool> ExistsByLicensePlate(string licensePlate);
    }
}
