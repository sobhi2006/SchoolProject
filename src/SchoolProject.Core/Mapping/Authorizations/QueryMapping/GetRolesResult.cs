using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Mapping.Authorizations;

public partial class AuthorizationProfile
{
    public void GetRolesResult()
    {
        CreateMap<IdentityRole, GetRoleResult>();
    }
}