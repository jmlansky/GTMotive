using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Default implementation of <see cref="ICreateVehicleUseCase"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">The create vehicle output port.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="dateTimeProvider">The date time provider.</param>
    public sealed class CreateVehicleUseCase(
        ICreateVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider) : ICreateVehicleUseCase
    {
        private readonly ICreateVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        /// <summary>
        /// Registers the vehicle and emits the result through the output port.
        /// </summary>
        /// <param name="input">The create vehicle input.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = Vehicle.RegisterForFleet(
                VehicleId.New(),
                input.Brand,
                input.Model,
                input.LicensePlate,
                input.ManufactureDate,
                _dateTimeProvider.UtcNow);

            await _vehicleRepository.Add(vehicle);
            await _unitOfWork.Save();

            var output = new CreateVehicleOutput(
                vehicle.Id.ToGuid(),
                vehicle.Brand,
                vehicle.Model,
                vehicle.LicensePlate,
                vehicle.ManufactureDate.Value,
                vehicle.Status.ToString());

            _outputPort.StandardHandle(output);
        }
    }
}
