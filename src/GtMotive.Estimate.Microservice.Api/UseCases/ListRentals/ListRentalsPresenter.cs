using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListRentals
{
    public sealed class ListRentalsPresenter : IWebApiPresenter, IListRentalsOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListRentalsOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var models = new List<RentalModel>();
            foreach (var item in response.Rentals)
            {
                models.Add(new RentalModel(item));
            }

            ActionResult = new OkObjectResult(new RentalsResponse(models));
        }
    }
}
