using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Default implementation of <see cref="IRentVehicleUseCase"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">The rent vehicle output port.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="dateTimeProvider">The date time provider.</param>
    public sealed class RentVehicleUseCase(
        IRentVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider) : IRentVehicleUseCase
    {
        private readonly IRentVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        /// <summary>
        /// Rents the vehicle to the customer and emits the result through the output port.
        /// </summary>
        /// <param name="input">The rent vehicle input.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetById(input.VehicleId);
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle '{input.VehicleId.ToGuid()}' was not found.");
                return;
            }

            if (vehicle.Status != VehicleStatus.Available)
            {
                _outputPort.VehicleNotAvailableHandle($"Vehicle '{input.VehicleId.ToGuid()}' is not available.");
                return;
            }

            if (await _rentalRepository.ExistsActiveByCustomer(input.CustomerId))
            {
                _outputPort.CustomerAlreadyHasActiveRentalHandle($"Customer '{input.CustomerId.ToGuid()}' already has an active rental.");
                return;
            }

            vehicle.Rent();

            var rental = Rental.Start(RentalId.New(), input.VehicleId, input.CustomerId, _dateTimeProvider.UtcNow, input.DueDateUtc);

            await _rentalRepository.Add(rental);
            await _vehicleRepository.Update(vehicle);
            await _unitOfWork.Save();

            var output = new RentVehicleOutput(
                rental.Id.ToGuid(),
                vehicle.Id.ToGuid(),
                rental.CustomerId.ToGuid(),
                rental.StartedAtUtc,
                rental.DueDateUtc,
                rental.PlannedDays,
                vehicle.Status.ToString());

            _outputPort.StandardHandle(output);
        }
    }
}
