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
    }
}
