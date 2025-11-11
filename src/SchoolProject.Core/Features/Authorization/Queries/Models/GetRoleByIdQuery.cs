using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models;

public class GetRoleByIdQuery(Guid Id) : IRequest<Response<GetRoleResult>>
{
    public Guid Id { get; set; } = Id;
}