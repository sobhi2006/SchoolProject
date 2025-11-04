using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Results;

namespace SchoolProject.Core.Features.Departments.Queries.Models;

public class GetDepartmentByIdQuery(Guid id) : IRequest<Response<DepartmentResponse>>
{
    public Guid Id { get; set; } = id;
}