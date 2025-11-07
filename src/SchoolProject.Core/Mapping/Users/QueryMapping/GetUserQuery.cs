using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users;

public partial class UserProfile
{
    public void GetUserMapping()
    {
        CreateMap<User, GetUserResponse>();
    }
}