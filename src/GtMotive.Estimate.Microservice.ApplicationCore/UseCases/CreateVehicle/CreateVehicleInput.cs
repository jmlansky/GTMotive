using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Input message for the create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        /// <param name="licensePlate">The vehicle license plate.</param>
        /// <param name="manufactureDate">The vehicle manufacture date.</param>
        public CreateVehicleInput(string brand, string model, string licensePlate, ManufactureDate manufactureDate)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets the vehicle license plate.
        /// </summary>
        public string LicensePlate { get; }

        /// <summary>
        /// Gets the vehicle manufacture date.
        /// </summary>
        public ManufactureDate ManufactureDate { get; }
    }
}
