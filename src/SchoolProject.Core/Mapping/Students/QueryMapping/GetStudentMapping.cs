using SchoolProject.Core.Features.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Students;

public partial class StudentProfile
{
    public void GetStudentMapping()
    {
        CreateMap<Student, GetStudentResponse>()
            .ForMember(dest => dest.DepartmentName, op => op.MapFrom(src => src.Department.DepartmentName));
    }
}