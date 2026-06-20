using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public sealed class CreateVehiclePresenter : IWebApiPresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CreateVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var viewModel = new CreateVehicleResponse(response);
            ActionResult = new CreatedResult($"/api/vehicles/{viewModel.VehicleId}", viewModel);
        }

        public void LicensePlateAlreadyExistsHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
