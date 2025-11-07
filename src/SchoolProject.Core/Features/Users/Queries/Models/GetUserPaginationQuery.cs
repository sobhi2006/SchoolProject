using MediatR;
using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Models;

public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserResponse>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}