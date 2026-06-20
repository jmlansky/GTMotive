namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output port for the create vehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>
    {
        /// <summary>
        /// Handles the case where a vehicle with the same license plate already exists.
        /// </summary>
        /// <param name="message">The conflict message.</param>
        void LicensePlateAlreadyExistsHandle(string message);
    }
}
