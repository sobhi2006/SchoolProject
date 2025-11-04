using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.Results;

namespace SchoolProject.Core.Features.Queries.Models;

public class GetStudentByIdQuery(Guid id) : IRequest<Response<GetStudentResponse>>
{
    public Guid Id { get; set; } = id;
}