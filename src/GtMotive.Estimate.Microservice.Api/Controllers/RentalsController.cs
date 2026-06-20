using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public sealed class RentalsController : ControllerBase
    {
        [HttpPost]
        public IActionResult RentVehicle() => Ok();

        [HttpPost("return")]
        public IActionResult ReturnVehicle() => Ok();
    }
}
