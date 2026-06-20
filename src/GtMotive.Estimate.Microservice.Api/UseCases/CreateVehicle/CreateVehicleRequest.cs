using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Request to register a new vehicle in the fleet.
    /// </summary>
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle brand.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the vehicle license plate.
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the manufacture date.
        /// </summary>
        [Required]
        [JsonRequired]
        public DateTime ManufactureDate { get; set; }
    }
}
