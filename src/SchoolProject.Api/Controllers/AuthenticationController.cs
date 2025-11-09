using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class AuthenticationController : AppController
{
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
}