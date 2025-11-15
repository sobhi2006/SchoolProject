using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Subjects.Commands.Handlers;

public class SubjectCommandHandler(ISubjectService subjectService, IMapper mapper)
                    : ResponseHandler,
                      IRequestHandler<AddSubjectCommand, Response<string>>,
                      IRequestHandler<UpdateSubjectCommand, Response<string>>,
                      IRequestHandler<DeleteSubjectCommand, Response<string>>
{
    private readonly ISubjectService _subjectService = subjectService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
    {
        var SubjectMapped = _mapper.Map<Subject>(request);
        var result = await _subjectService.AddSubjectAsync(SubjectMapped);
        return result ? Created<string>("") : BadRequest<string>();
    }

    public async Task<Response<string>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var SubjectMapped = _mapper.Map<Subject>(request);
        await _subjectService.UpdateSubjectAsync(SubjectMapped);
        return Success<string>("Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _subjectService.DeleteSubjectAsync(request.SubjectId);
        return result ? Deleted<string>() : BadRequest<string>("Failed to delete");
    }
}