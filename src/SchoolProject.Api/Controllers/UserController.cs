using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]

public class UserController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserCommand request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}