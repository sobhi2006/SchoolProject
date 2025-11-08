using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]

public class UserController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetUsersPagination([FromQuery] GetUserPaginationQuery request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var response = await Mediator.Send(new GetUserByIdQuery(id));
        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var response = await Mediator.Send(new DeleteUserCommand(id));
        return NewResult(response);
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordUser([FromBody] ChangePasswordCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
}