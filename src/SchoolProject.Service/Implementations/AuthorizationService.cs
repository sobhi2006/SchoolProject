using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : IAuthorizationService
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<bool> AddRoleAsync(string roleName)
    {
        var IdentityRole = new IdentityRole(roleName);
        var result = await _roleManager.CreateAsync(IdentityRole);

        return result.Succeeded;
    }

    public async Task<bool> DeleteRoleAsync(Guid Id)
    {
        var role = await _roleManager.FindByIdAsync(Id.ToString()) ?? throw new ValidationException("Role not found");
        var UsersHaveRole = await _userManager.GetUsersInRoleAsync(role.Name!);
        if (UsersHaveRole?.Count > 0)
            throw new ValidationException("Role exists with users");
        var result = await _roleManager.DeleteAsync(role);
        return result.Succeeded;
    }

    public async Task<IdentityRole?> GetIdentityRoleByIdAsync(Guid Id)
    {
        return await _roleManager.FindByIdAsync(Id.ToString());
    }

    public async Task<List<IdentityRole>> GetIdentityRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<bool> IsRoleExist(string roleName)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task<bool> IsRoleExist(Guid Id)
    {
        return await _roleManager.Roles.AnyAsync(r => r.Id == Id.ToString());
    }

    public async Task<bool> UpdateRoleAsync(Guid Id, string roleName)
    {
        if (await _roleManager.Roles.AnyAsync(r => r.Name!.Equals(roleName, StringComparison.OrdinalIgnoreCase)))
            throw new ValidationException("Role is exist");
    
        var result = await _roleManager.UpdateAsync(new()
        {
            Id = Id.ToString(),
            Name = roleName
        });
        return result.Succeeded;
    }
}