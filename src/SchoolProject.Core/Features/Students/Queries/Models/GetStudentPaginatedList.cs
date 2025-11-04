using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Helpers.Enums;

namespace SchoolProject.Core.Features.Queries.Models;

public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrdering OrderBy { get; set; }
    public string Search { get; set; }
}