using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Value object representing the manufacture date of a vehicle.
    /// </summary>
    public readonly struct ManufactureDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDate"/> struct.
        /// </summary>
        /// <param name="value">The manufacture date.</param>
        public ManufactureDate(DateTime value)
        {
            if (value == default)
            {
                throw new DomainException("Manufacture date is required.");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the manufacture date value.
        /// </summary>
        public DateTime Value { get; }
    }
}
