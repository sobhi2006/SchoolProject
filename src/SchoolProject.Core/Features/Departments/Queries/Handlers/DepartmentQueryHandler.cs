using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers;

public class DepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService) : ResponseHandler,
                                        IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentResponse>>,
                                        IRequestHandler<GetDepartmentPaginatedQuery, PaginatedResult<DepartmentResponse>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDepartmentService _departmentService = departmentService;

    public async Task<Response<DepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(request.Id);
        if (department is null)
            return NotFound<DepartmentResponse>($"department with {request.Id} not found");

        var result = _mapper.Map<DepartmentResponse>(department);
        return Success(result);
    }

    public Task<PaginatedResult<DepartmentResponse>> Handle(GetDepartmentPaginatedQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Department, DepartmentResponse>> expression = d =>
                    new DepartmentResponse(d.Id, d.DepartmentName, d.Manager.Name,
                                           d.Students.ToList(),
                                           d.Instructors.ToList(),
                                           d.DepartmentSubjects.Select(ds => ds.Subject).ToList(), _mapper);

        var result = _departmentService.GetQueryableDepartment()
                                       .Select(expression)
                                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}