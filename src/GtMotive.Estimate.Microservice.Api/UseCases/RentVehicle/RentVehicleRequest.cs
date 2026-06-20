using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// Request to rent a vehicle to a customer.
    /// </summary>
    public sealed class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        [Required]
        [JsonRequired]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Required]
        [JsonRequired]
        public Guid CustomerId { get; set; }
    }
}
