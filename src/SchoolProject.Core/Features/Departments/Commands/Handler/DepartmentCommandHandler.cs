using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Departments.Commands.Handler;

public class DepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
                        : ResponseHandler,
                          IRequestHandler<AddDepartmentCommand, Response<string>>,
                          IRequestHandler<UpdateDepartmentCommand, Response<string>>,
                          IRequestHandler<DeleteDepartmentCommand, Response<string>>
{
    private readonly IDepartmentService _departmentService = departmentService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        var DepartmentMapped = _mapper.Map<Department>(request);
        var result = await _departmentService.AddDepartmentAsync(DepartmentMapped);
        return result ? Created<string>("") : BadRequest<string>();
    }

    public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var DepartmentMapped = _mapper.Map<Department>(request);
        await _departmentService.UpdateDepartmentAsync(DepartmentMapped);
        return Success<string>("Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _departmentService.DeleteDepartmentAsync(request.DepartmentId);
        return result ? Deleted<string>() : BadRequest<string>("department is related with data");
    }
}