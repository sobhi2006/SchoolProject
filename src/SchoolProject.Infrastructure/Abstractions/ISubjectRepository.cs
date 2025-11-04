using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstractions;

public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
{
    
}