using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Abstraction over the system clock so domain time rules stay deterministic and testable.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        DateTime UtcNow { get; }
    }
}
