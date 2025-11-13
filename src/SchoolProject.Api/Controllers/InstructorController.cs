using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]

public class InstructorController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromForm] AddInstructorCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
}