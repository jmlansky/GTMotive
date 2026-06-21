using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Aggregate root representing a vehicle of the rental fleet.
    /// </summary>
    public sealed class Vehicle
    {
        private Vehicle(VehicleId id, string brand, string model, string licensePlate, ManufactureDate manufactureDate, VehicleStatus status)
        {
            Id = id;
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
            Status = status;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId Id { get; }

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

        /// <summary>
        /// Gets the vehicle availability status.
        /// </summary>
        public VehicleStatus Status { get; private set; }

        /// <summary>
        /// Registers a new vehicle for the fleet, enforcing the fleet invariants.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        /// <param name="licensePlate">The vehicle license plate.</param>
        /// <param name="manufactureDate">The vehicle manufacture date.</param>
        /// <param name="utcNow">The current UTC date used to evaluate the fleet age rule.</param>
        /// <returns>A new available <see cref="Vehicle"/>.</returns>
        public static Vehicle RegisterForFleet(VehicleId id, string brand, string model, string licensePlate, ManufactureDate manufactureDate, DateTime utcNow)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new DomainException("Vehicle brand is required.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new DomainException("Vehicle model is required.");
            }

            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                throw new DomainException("Vehicle license plate is required.");
            }

            if (manufactureDate.Value > utcNow)
            {
                throw new DomainException("Manufacture date cannot be in the future.");
            }

            if (manufactureDate.Value < utcNow.AddYears(-5))
            {
                throw new VehicleTooOldException("A vehicle manufactured more than 5 years ago cannot join the fleet.");
            }

            return new Vehicle(id, brand, model, licensePlate, manufactureDate, VehicleStatus.Available);
        }

        /// <summary>
        /// Reconstitutes a vehicle from persistence without re-evaluating creation invariants.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        /// <param name="licensePlate">The vehicle license plate.</param>
        /// <param name="manufactureDate">The vehicle manufacture date.</param>
        /// <param name="status">The vehicle status.</param>
        /// <returns>The reconstituted <see cref="Vehicle"/>.</returns>
        public static Vehicle Rehydrate(VehicleId id, string brand, string model, string licensePlate, ManufactureDate manufactureDate, VehicleStatus status)
        {
            return new Vehicle(id, brand, model, licensePlate, manufactureDate, status);
        }

        /// <summary>
        /// Marks the vehicle as rented.
        /// </summary>
        public void Rent()
        {
            if (Status != VehicleStatus.Available)
            {
                throw new DomainException("Only an available vehicle can be rented.");
            }

            Status = VehicleStatus.Rented;
        }

        /// <summary>
        /// Marks the vehicle as available again after a return.
        /// </summary>
        public void Return()
        {
            if (Status != VehicleStatus.Rented)
            {
                throw new DomainException("Only a rented vehicle can be returned.");
            }

            Status = VehicleStatus.Available;
        }
    }
}
