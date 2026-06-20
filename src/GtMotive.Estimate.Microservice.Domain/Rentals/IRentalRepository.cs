using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Rentals
{
    /// <summary>
    /// Persistence port for the <see cref="Rental"/> aggregate root.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Adds a rental to the store.
        /// </summary>
        /// <param name="rental">The rental to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Add(Rental rental);

        /// <summary>
        /// Determines whether the customer already has an open rental.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns><c>true</c> when the customer has an open rental.</returns>
        Task<bool> ExistsActiveByCustomer(CustomerId customerId);
    }
}
