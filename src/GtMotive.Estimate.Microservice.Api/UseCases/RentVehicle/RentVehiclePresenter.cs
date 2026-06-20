using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var viewModel = new RentalResponse(response);
            ActionResult = new CreatedResult($"/api/rentals/{viewModel.RentalId}", viewModel);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void VehicleNotAvailableHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }

        public void CustomerAlreadyHasActiveRentalHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
