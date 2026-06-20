namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for the rent vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case where the requested vehicle is not available.
        /// </summary>
        /// <param name="message">The conflict message.</param>
        void VehicleNotAvailableHandle(string message);

        /// <summary>
        /// Handles the case where the customer already has an open rental.
        /// </summary>
        /// <param name="message">The conflict message.</param>
        void CustomerAlreadyHasActiveRentalHandle(string message);
    }
}
