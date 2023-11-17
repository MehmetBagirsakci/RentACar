using Application.Features.Fuels.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            CreatedFuelResponse response = await Mediator.Send(createFuelCommand);
            return Ok(response);
        }
    }
}
