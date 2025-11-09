using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstractions;

public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
{
    
}