using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public sealed class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ReturnVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            ActionResult = new OkObjectResult(new ReturnConfirmationResponse(response));
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void VehicleNotRentedHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
