namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Availability status of a vehicle in the fleet.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// The vehicle is available to be rented.
        /// </summary>
        Available,

        /// <summary>
        /// The vehicle is currently rented.
        /// </summary>
        Rented,
    }
}
