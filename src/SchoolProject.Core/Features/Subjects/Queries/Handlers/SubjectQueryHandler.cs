using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Subjects.Queries.Handlers;

public class SubjectQueryHandler(ISubjectService subjectService, IMapper mapper)
                : ResponseHandler,
                  IRequestHandler<GetSubjectByIdQuery, Response<GetSubjectResponse>>,
                  IRequestHandler<GetSubjectPaginatedQuery, PaginatedResult<GetSubjectResponse>>
{
    private readonly ISubjectService _subjectService = subjectService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<GetSubjectResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        var Subject = await _subjectService.GetSubjectByIdAsync(request.SubjectId);
        var SubjectMapped = _mapper.Map<GetSubjectResponse>(Subject);
        return Success(SubjectMapped);
    }

    public Task<PaginatedResult<GetSubjectResponse>> Handle(GetSubjectPaginatedQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Subject, GetSubjectResponse>> expression = s =>
                    new GetSubjectResponse(s.Id, s.SubjectName, s.Period);

        var result = _subjectService.GetSubjectsQueryable()
                                       .Select(expression)
                                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}