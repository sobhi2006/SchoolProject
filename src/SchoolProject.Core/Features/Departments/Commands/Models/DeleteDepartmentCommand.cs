using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Models;

public class DeleteDepartmentCommand(Guid Id) : IRequest<Response<string>>
{
    public Guid DepartmentId { get; set; } = Id;
}