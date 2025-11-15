using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.Models;

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

    [HttpDelete("{instructorId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid instructorId)
    {
        var response = await Mediator.Send(new DeleteInstructorCommand(instructorId));
        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateInstructor(UpdateInstructorCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetInstructorById(Guid Id)
    {
        var response = await Mediator.Send(new GetInstructorByIdQuery(Id));
        return Ok(response);
    }
}