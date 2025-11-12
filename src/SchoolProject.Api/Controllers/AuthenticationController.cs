using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;

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
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPost("confirm-email-ByCode")]
    public async Task<IActionResult> ConfirmEmailByCode([FromQuery] ConfirmEmailCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPost("code-email-confirm/{UserId:guid}")]
    public async Task<IActionResult> GetCodeToConfirmEmail(Guid UserId)
    {
        var response = await Mediator.Send(new SendCodeToConfirmEmail(UserId));
        return NewResult(response);
    }
}