using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Value object that uniquely identifies a vehicle.
    /// </summary>
    public readonly struct VehicleId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="value">The identifier value.</param>
        public VehicleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("Vehicle id is required.");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the identifier value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Creates a new unique vehicle identifier.
        /// </summary>
        /// <returns>A new <see cref="VehicleId"/>.</returns>
        public static VehicleId New()
        {
            return new VehicleId(Guid.NewGuid());
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
