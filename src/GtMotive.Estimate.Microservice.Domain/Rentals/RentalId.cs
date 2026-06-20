using System;

namespace GtMotive.Estimate.Microservice.Domain.Rentals
{
    /// <summary>
    /// Value object that uniquely identifies a rental.
    /// </summary>
    public readonly struct RentalId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalId"/> struct.
        /// </summary>
        /// <param name="value">The identifier value.</param>
        public RentalId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("Rental id is required.");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the identifier value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Creates a new unique rental identifier.
        /// </summary>
        /// <returns>A new <see cref="RentalId"/>.</returns>
        public static RentalId New()
        {
            return new RentalId(Guid.NewGuid());
        }

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
