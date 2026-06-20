using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output message for the list available vehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The available vehicles.</param>
        public ListAvailableVehiclesOutput(IReadOnlyCollection<AvailableVehicleItem> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the available vehicles.
        /// </summary>
        public IReadOnlyCollection<AvailableVehicleItem> Vehicles { get; }
    }
}
