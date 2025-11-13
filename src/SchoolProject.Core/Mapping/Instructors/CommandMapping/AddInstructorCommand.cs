using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Instructors;

public partial class InstructorProfile
{
    public void AddInstructorMapping()
    {
        CreateMap<AddInstructorCommand, Instructor>();
    }
}