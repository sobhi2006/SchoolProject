using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstractions;

public interface IStudentSubjectService
{
    public Task<bool> AddStudentToSubject(Guid StudentId, Guid SubjectId, float Degree);
    public Task UpdateStudentToSubject(Guid StudentId, Guid SubjectId, float Degree);
    public Task<bool> DeleteStudentToSubject(Guid StudentId, Guid SubjectId);
    public Task<bool> IsStudentExistInSubject(Guid StudentId, Guid SubjectId);
}
