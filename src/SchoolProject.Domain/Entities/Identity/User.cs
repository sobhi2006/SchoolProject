using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Domain.Entities.Identity;

public class User : IdentityUser
{
    public string FullName { get; set; } = null!;
    public string? Address { get; set; } = null!;
    public string? Country { get; set; } = null!;
}