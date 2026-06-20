using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// The vehicles available to rent.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AvailableVehiclesResponse"/> class.
    /// </remarks>
    /// <param name="vehicles">The available vehicles.</param>
    public sealed class AvailableVehiclesResponse(IReadOnlyCollection<AvailableVehicleModel> vehicles)
    {
        /// <summary>
        /// Gets the available vehicles.
        /// </summary>
        [Required]
        public IReadOnlyCollection<AvailableVehicleModel> Vehicles { get; } = vehicles;
    }
}
