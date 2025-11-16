using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Departments;

public partial class DepartmentProfile
{
    public void UpdateDepartmentMapping()
    {
        CreateMap<UpdateDepartmentCommand, Department>();
    }
}