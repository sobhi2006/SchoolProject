using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers;

public class InstructorCommandHandler(IInstructorService instructorService, IMapper mapper)
                                     : ResponseHandler,
                                       IRequestHandler<AddInstructorCommand, Response<string>>,
                                       IRequestHandler<UpdateInstructorCommand, Response<string>>,
                                       IRequestHandler<DeleteInstructorCommand, Response<string>>
{
    private readonly IInstructorService _InstructorService = instructorService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructorMapped = _mapper.Map<Instructor>(request);
        await _InstructorService.AddInstructorAsync(instructorMapped, request.Image);
        return Created<string>("");
    }

    public async Task<Response<string>> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
    {
        var InstructorMapped = _mapper.Map<Instructor>(request);
        await _InstructorService.UpdateInstructorAsync(InstructorMapped);
        return Success<string>("Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        var result = await _InstructorService.DeleteInstructorAsync(request.InstructorId);
        return result ? Deleted<string>() : BadRequest<string>("Instructor is related with data");
    }
}