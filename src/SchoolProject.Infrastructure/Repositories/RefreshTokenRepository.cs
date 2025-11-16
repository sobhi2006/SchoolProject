using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class RefreshTokenRepository(AppDbContext context) : GenericRepositoryAsync<UserRefreshToken>(context),
                                                            IRefreshTokenRepository
{
    
}