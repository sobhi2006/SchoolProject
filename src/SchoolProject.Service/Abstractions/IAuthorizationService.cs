using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Service.Abstractions;

public interface IAuthorizationService
{
    public Task<bool> AddRoleAsync(string roleName);
    public Task<bool> DeleteRoleAsync(Guid Id);
    public Task<bool> IsRoleExist(string roleName);
    public Task<bool> IsRoleExist(Guid Id);
    public Task<bool> UpdateRoleAsync(Guid Id, string roleName);
    public Task<List<IdentityRole>> GetIdentityRolesAsync();
    public Task<IdentityRole?> GetIdentityRoleByIdAsync(Guid Id);
}