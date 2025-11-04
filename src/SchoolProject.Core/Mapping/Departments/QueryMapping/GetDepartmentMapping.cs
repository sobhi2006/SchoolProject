using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Departments;

public partial class DepartmentProfile
{
    public void GetDepartmentMapping()
    {
        CreateMap<Department, DepartmentResponse>()
                .ForMember(dr => dr.ManagerName, options => options.MapFrom(d => d.Manager.Name))
                .ForMember(dr => dr.Subjects, options => options.MapFrom(d => d.DepartmentSubjects));
        CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dr => dr.Id, options => options.MapFrom(d => d.SubjectId))
                .ForMember(dr => dr.SubjectName, options => options.MapFrom(d => d.Subject.SubjectName));
        CreateMap<Student, StudentResponse>();
        CreateMap<Instructor, InstructorResponse>();
    }
}

