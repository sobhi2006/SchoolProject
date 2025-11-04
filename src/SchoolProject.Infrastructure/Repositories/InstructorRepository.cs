using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class InstructorRepository(AppDbContext context ) : GenericRepositoryAsync<Instructor>(context),
                                                           IInstructorRepository
{
    
}