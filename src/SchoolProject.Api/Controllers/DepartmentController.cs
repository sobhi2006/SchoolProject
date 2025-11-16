using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Features.Departments.Queries.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]

public class DepartmentController : AppController
{
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetDepartmentById(Guid Id)
    {
        var response = await Mediator.Send(new GetDepartmentByIdQuery(Id));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] AddDepartmentCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand request)
    {
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpDelete("{departmentId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid departmentId)
    {
        var response = await Mediator.Send(new DeleteDepartmentCommand(departmentId));
        return NewResult(response);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetStudentsPagination([FromQuery] GetDepartmentPaginatedQuery request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}