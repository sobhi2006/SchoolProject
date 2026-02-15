using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Transportation.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Authorize]
public class TransportationController : AppController
{
    [HttpGet("recommendation")]
    public async Task<IActionResult> GetRecommendation([FromQuery] GetTransportationRecommendationQuery request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
}
