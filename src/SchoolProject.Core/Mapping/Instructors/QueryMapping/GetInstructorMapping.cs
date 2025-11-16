using SchoolProject.Core.Features.Instructors.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Instructors;

public partial class InstructorProfile
{
    public void GetInstructorMapping()
    {
        CreateMap<Instructor, GetInstructorResponse>();
    }
}