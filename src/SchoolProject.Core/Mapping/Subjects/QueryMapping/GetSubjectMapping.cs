using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Subjects;

public partial class SubjectProfile
{
    public void GetSubjectMapping()
    {
        CreateMap<Subject, GetSubjectResponse>();
    }
}