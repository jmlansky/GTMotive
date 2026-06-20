using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Default implementation of <see cref="IListAvailableVehiclesUseCase"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">The list available vehicles output port.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    public sealed class ListAvailableVehiclesUseCase(
        IListAvailableVehiclesOutputPort outputPort,
        IVehicleRepository vehicleRepository) : IListAvailableVehiclesUseCase
    {
        private readonly IListAvailableVehiclesOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <summary>
        /// Loads the available vehicles and emits them through the output port.
        /// </summary>
        /// <param name="input">The list available vehicles input.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.ListAvailable();

            var items = new List<AvailableVehicleItem>();
            foreach (var vehicle in vehicles)
            {
                items.Add(new AvailableVehicleItem(
                    vehicle.Id.ToGuid(),
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.LicensePlate,
                    vehicle.ManufactureDate.Value));
            }

            _outputPort.StandardHandle(new ListAvailableVehiclesOutput(items));
        }
    }
}
