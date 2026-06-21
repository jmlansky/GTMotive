using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rentals;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals
{
    /// <summary>
    /// Default implementation of <see cref="IListRentalsUseCase"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListRentalsUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">The list rentals output port.</param>
    /// <param name="rentalRepository">The rental repository.</param>
    public sealed class ListRentalsUseCase(
        IListRentalsOutputPort outputPort,
        IRentalRepository rentalRepository) : IListRentalsUseCase
    {
        private readonly IListRentalsOutputPort _outputPort = outputPort;
        private readonly IRentalRepository _rentalRepository = rentalRepository;

        /// <summary>
        /// Loads every rental and emits them through the output port.
        /// </summary>
        /// <param name="input">The list rentals input.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ListRentalsInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var rentals = await _rentalRepository.ListAll();

            var items = new List<RentalItem>();
            foreach (var rental in rentals)
            {
                items.Add(new RentalItem(rental));
            }

            _outputPort.StandardHandle(new ListRentalsOutput(items));
        }
    }
}
