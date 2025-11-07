using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users;

public partial class UserProfile
{
    public void UpdateUserMapping()
    {
        CreateMap<UpdateUserCommand, User>();
    }
}