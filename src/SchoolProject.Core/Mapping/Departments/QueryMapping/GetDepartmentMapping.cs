using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Departments;

public partial class DepartmentProfile
{
    public void GetDepartmentMapping()
    {
        CreateMap<Department, DepartmentResponse>()
                .ForMember(dr => dr.ManagerName, options => options.MapFrom(d => d.Manager.Name));
        CreateMap<Student, StudentResponse>();
        CreateMap<Instructor, InstructorResponse>();
    }
}

