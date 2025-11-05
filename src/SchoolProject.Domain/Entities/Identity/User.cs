using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Domain.Entities.Identity;

public class User : IdentityUser
{
    public string Address { get; set; } = null!;
    public string Country { get; set; } = null!;
}