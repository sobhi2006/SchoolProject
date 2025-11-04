using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Students.Commands.Handler;

public class StudentCommandHandler(IStudentService studentService, IMapper mapper) : ResponseHandler, IRequestHandler<AddStudentCommand, Response<Student>>,
                                                                                IRequestHandler<UpdateStudentCommand, Response<Student>>,
                                                                                IRequestHandler<DeleteStudentCommand, Response<string>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<Student>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var StudentMapped = _mapper.Map<Student>(request);
        var result = await _studentService.AddAsync(StudentMapped);
        return result is null ? BadRequest<Student>("Student was found") : Created<Student>(result);
    }

    public async Task<Response<Student>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var Student = await _studentService.GetStudentByIdAsync(request.Id);
        if (Student is null)
            return NotFound<Student>("Student not found");

        var StudentMapped = _mapper.Map(request, Student);
        var result = await _studentService.UpdateAsync(StudentMapped);
        return result is null ? BadRequest<Student>("Not Updated") : Success<Student>(result, "Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var Student = await _studentService.GetStudentByIdAsync(request.Id);
        if (Student is null)
            return NotFound<string>("Student not found");

        await _studentService.DeleteAsync(Student);
        return Deleted<string>();
    }
}