using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Features.Instructors.Queries.Results;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers;

public class InstructorQueryHandler(IInstructorService instructorService, IMapper mapper)
                    : ResponseHandler, IRequestHandler<GetInstructorByIdQuery, Response<GetInstructorResponse>>
{
    private readonly IInstructorService _instructorService = instructorService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<GetInstructorResponse>> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _instructorService.GetInstructorById(request.InstructorId);
        if (result is null)
            return NotFound<GetInstructorResponse>("Instructor not found");

        var resultMapped = _mapper.Map<GetInstructorResponse>(result);
        return Success(resultMapped);
    }
}