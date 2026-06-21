using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Default implementation of <see cref="IReturnVehicleUseCase"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">The return vehicle output port.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="dateTimeProvider">The date time provider.</param>
    public sealed class ReturnVehicleUseCase(
        IReturnVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider) : IReturnVehicleUseCase
    {
        private readonly IReturnVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        /// <summary>
        /// Closes the vehicle open rental and emits the result through the output port.
        /// </summary>
        /// <param name="input">The return vehicle input.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetById(input.VehicleId);
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle '{input.VehicleId.ToGuid()}' was not found.");
                return;
            }

            var rental = await _rentalRepository.GetActiveByVehicle(input.VehicleId);
            if (rental is null)
            {
                _outputPort.VehicleNotRentedHandle($"Vehicle '{input.VehicleId.ToGuid()}' has no active rental.");
                return;
            }

            var endedAtUtc = input.ReturnedAtUtc ?? _dateTimeProvider.UtcNow;
            rental.Close(endedAtUtc);
            vehicle.Return();

            await _rentalRepository.Update(rental);
            await _vehicleRepository.Update(vehicle);
            await _unitOfWork.Save();

            var output = new ReturnVehicleOutput(
                vehicle.Id.ToGuid(),
                rental.Id.ToGuid(),
                endedAtUtc,
                rental.ActualDays,
                vehicle.Status.ToString());

            _outputPort.StandardHandle(output);
        }
    }
}
