using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Core.Features.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Queries.Handler;

public class StudentQueryHandler(IStudentService studentService,
                                 IMapper mapper) : ResponseHandler,
                IRequestHandler<GetStudentQuery, Response<List<GetStudentResponse>>>,
                IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
                IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentResponse>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;
    public async Task<Response<List<GetStudentResponse>>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentService.GetStudentsAsync();
        var studentsMapped = _mapper.Map<List<GetStudentResponse>>(students);

        var result = Success(studentsMapped);
        result.Meta = new { Count = result.Data.Count };
        return result;
    }

    public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);

        if (student is null)
            return NotFound<GetStudentResponse>("Student not found");

        var studentsMapped = _mapper.Map<GetStudentResponse>(student);
        return Success(studentsMapped);
    }

    public Task<PaginatedResult<GetStudentResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Student, GetStudentResponse>> expression = e =>
            new GetStudentResponse(e.Id, e.Name, e.Address, e.Phone, e.Department.DepartmentName);

        var Filter = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
        var result = Filter.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}