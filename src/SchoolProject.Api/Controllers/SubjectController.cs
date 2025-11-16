using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]

public class SubjectController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddSubjectCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubject(UpdateSubjectCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var response = await Mediator.Send(new DeleteSubjectCommand(id));
        return NewResult(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var response = await Mediator.Send(new GetSubjectByIdQuery(id));
        return NewResult(response);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetStudentsPagination([FromQuery] GetSubjectPaginatedQuery request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}