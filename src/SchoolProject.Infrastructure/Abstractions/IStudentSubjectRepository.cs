using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstractions;

public interface IStudentSubjectRepository : IGenericRepositoryAsync<StudentSubject>
{
    public Task<bool> IsStudentExistInSubject(Guid StudnetId, Guid SubjectId);
}
