using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Emails.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Authorize]
public class EmailController : AppController
{
    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand request)
    {
        var Response = await Mediator.Send(request);
        return NewResult(Response);
    }
}