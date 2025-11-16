using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.Results;

namespace SchoolProject.Core.Features.Users.Queries.Models;

public class GetUserByIdQuery(Guid id) : IRequest<Response<GetUserResponse>>
{
    public Guid Id { get; set; } = id;
}
