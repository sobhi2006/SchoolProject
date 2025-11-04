using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Features.Students.Commands.Models;

public class UpdateStudentCommand : IRequest<Response<Student>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public Guid DepartmentId { get; set; }
}