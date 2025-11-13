using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models;

public class AddInstructorCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? SupervisorId { get; set; }
    public IFormFile? Image { get; set; }
}