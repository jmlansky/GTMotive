using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.ListRentals;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public sealed class RentalsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListRentals()
        {
            var presenter = await mediator.Send(new ListRentalsRequest());
            return presenter.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> RentVehicle([FromBody][Required] RentVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnVehicle([FromBody][Required] ReturnVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
