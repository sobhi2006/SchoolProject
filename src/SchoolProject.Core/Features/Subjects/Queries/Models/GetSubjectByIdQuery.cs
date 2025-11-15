using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Results;

namespace SchoolProject.Core.Features.Subjects.Queries.Models;

public class GetSubjectByIdQuery(Guid Id) : IRequest<Response<GetSubjectResponse>>
{
    public Guid SubjectId { get; set; } = Id;
}