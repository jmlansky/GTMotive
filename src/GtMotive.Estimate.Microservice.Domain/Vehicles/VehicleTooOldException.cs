using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Exception thrown when a vehicle is too old to join the fleet.
    /// </summary>
    public sealed class VehicleTooOldException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
        /// </summary>
        public VehicleTooOldException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleTooOldException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleTooOldException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
