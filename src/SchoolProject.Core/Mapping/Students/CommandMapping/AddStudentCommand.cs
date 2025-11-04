using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students;

public partial class StudentProfile
{
    public void AddStudentMapping()
    {
        CreateMap<AddStudentCommand, Student>()
            .ForMember(dest => dest.DepartmentId, op => op.MapFrom(src => src.DepartmentId));
    }
}