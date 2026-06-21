using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListRentals
{
    /// <summary>
    /// The list of rentals.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentalsResponse"/> class.
    /// </remarks>
    /// <param name="rentals">The rentals.</param>
    public sealed class RentalsResponse(IReadOnlyCollection<RentalModel> rentals)
    {
        /// <summary>
        /// Gets the rentals.
        /// </summary>
        [Required]
        public IReadOnlyCollection<RentalModel> Rentals { get; } = rentals;
    }
}
