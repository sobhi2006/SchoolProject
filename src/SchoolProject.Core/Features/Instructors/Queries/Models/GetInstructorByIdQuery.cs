using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Results;

namespace SchoolProject.Core.Features.Instructors.Queries.Models;

public class GetInstructorByIdQuery(Guid Id) : IRequest<Response<GetInstructorResponse>>
{
    public Guid InstructorId { get; set; } = Id;
}