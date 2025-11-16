using AutoMapper;

namespace SchoolProject.Core.Mapping.Authorizations;

public partial class AuthorizationProfile : Profile
{
    public AuthorizationProfile()
    {
        GetRolesResult();
    }
}