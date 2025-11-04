using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers.Base;
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
}