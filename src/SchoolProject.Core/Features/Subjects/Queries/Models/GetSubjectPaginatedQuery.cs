using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Subjects.Queries.Models;


public class GetSubjectPaginatedQuery : IRequest<PaginatedResult<GetSubjectResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}