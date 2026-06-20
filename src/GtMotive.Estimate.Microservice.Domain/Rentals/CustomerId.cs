using System;

namespace GtMotive.Estimate.Microservice.Domain.Rentals
{
    /// <summary>
    /// Value object that identifies the customer renting a vehicle.
    /// </summary>
    public readonly struct CustomerId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerId"/> struct.
        /// </summary>
        /// <param name="value">The identifier value.</param>
        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("Customer id is required.");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the identifier value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Returns the identifier as a <see cref="Guid"/>.
        /// </summary>
        /// <returns>The underlying <see cref="Guid"/>.</returns>
        public Guid ToGuid()
        {
            return Value;
        }
    }
}
