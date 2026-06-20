using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public sealed class RentalsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RentVehicle([FromBody][Required] RentVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpPost("return")]
        public IActionResult ReturnVehicle() => Ok();
    }
}
