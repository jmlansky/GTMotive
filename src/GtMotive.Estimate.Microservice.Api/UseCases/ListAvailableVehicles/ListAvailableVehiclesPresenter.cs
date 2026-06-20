using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    public sealed class ListAvailableVehiclesPresenter : IWebApiPresenter, IListAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var models = new List<AvailableVehicleModel>();
            foreach (var item in response.Vehicles)
            {
                models.Add(new AvailableVehicleModel(item));
            }

            ActionResult = new OkObjectResult(new AvailableVehiclesResponse(models));
        }
    }
}
