using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Mapping.Subjects;

public partial class SubjectProfile
{
    public void AddSubjectMapping()
    {
        CreateMap<AddSubjectCommand, Subject>();
    }
}