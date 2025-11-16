using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Queries.Models;

public class GetDepartmentPaginatedQuery : IRequest<PaginatedResult<DepartmentResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}