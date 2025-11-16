using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using Serilog;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
[Authorize]

public class StudentController : AppController
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var response = await Mediator.Send(new GetStudentQuery());
        return Ok(response);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetStudentsPagination([FromQuery] GetStudentPaginatedListQuery request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetStudentById(Guid Id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(Id));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(AddStudentCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(UpdateStudentCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("{studentId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        var response = await Mediator.Send(new DeleteStudentCommand()
        {
            Id = studentId
        });
        return NewResult(response);
    }
}