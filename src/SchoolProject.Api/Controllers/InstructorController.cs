using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Authorize]
public class InstructorController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateInstructor([FromForm] AddInstructorCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("{instructorId:guid}")]
    public async Task<IActionResult> DeleteInstructor(Guid instructorId)
    {
        var response = await Mediator.Send(new DeleteInstructorCommand(instructorId));
        return NewResult(response);
    }

    [HttpPut]
    // [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateInstructor([FromForm]UpdateInstructorCommand request)
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