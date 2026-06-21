namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output port for the return vehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case where the vehicle has no open rental to close.
        /// </summary>
        /// <param name="message">The conflict message.</param>
        void VehicleNotRentedHandle(string message);
    }
}
