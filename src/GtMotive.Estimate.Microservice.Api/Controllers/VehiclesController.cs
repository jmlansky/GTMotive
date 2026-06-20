using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public sealed class VehiclesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody][Required] CreateVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet("available")]
        public async Task<IActionResult> ListAvailableVehicles()
        {
            var presenter = await mediator.Send(new ListAvailableVehiclesRequest());
            return presenter.ActionResult;
        }
    }
}
