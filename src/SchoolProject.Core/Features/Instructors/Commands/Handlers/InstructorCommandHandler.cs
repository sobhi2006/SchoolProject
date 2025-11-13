using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers;

public class InstructorCommandHandler(IInstructorService instructorService, IMapper mapper)
                                     : ResponseHandler,
                                       IRequestHandler<AddInstructorCommand, Response<string>>
{
    private readonly IInstructorService _InstructorService = instructorService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructorMapped = _mapper.Map<Instructor>(request);
        await _InstructorService.AddInstructorAsync(instructorMapped, request.Image);
        return Created<string>("");
    }
}