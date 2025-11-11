using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Authorize]

public class AuthorizationController : AppController
{
    [HttpPost("role")]
    public async Task<IActionResult> AddRole([FromBody] AddRoleCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPut("role")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("role/{Id:guid}")]
    public async Task<IActionResult> DeleteRole(Guid Id)
    {
        var response = await Mediator.Send(new DeleteRoleCommand(Id));
        return NewResult(response);
    }

    [HttpGet("roles-list")]
    public async Task<IActionResult> GetRolesList()
    {
        var response = await Mediator.Send(new GetRolesListQuery());
        return NewResult(response);
    }

    [HttpGet("role/{Id:guid}")]
    public async Task<IActionResult> GetRoleById(Guid Id)
    {
        var response = await Mediator.Send(new DeleteRoleCommand(Id));
        return NewResult(response);
    }

    [HttpPut("user-role")]
    public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
}