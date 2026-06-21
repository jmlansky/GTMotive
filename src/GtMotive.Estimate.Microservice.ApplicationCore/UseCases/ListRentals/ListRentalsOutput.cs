using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals
{
    /// <summary>
    /// Output message for the list rentals use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListRentalsOutput"/> class.
    /// </remarks>
    /// <param name="rentals">The rentals.</param>
    public sealed class ListRentalsOutput(IReadOnlyCollection<RentalItem> rentals) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the rentals.
        /// </summary>
        public IReadOnlyCollection<RentalItem> Rentals { get; } = rentals;
    }
}
