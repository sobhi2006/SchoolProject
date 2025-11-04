using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstractions;

public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
{
    
}