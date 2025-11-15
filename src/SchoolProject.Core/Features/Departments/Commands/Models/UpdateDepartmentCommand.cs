using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Models;

public class UpdateDepartmentCommand(Guid DepartmentId) : AddDepartmentCommand
{
    public Guid departmentId { get; set; } = DepartmentId;
}