using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Results;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Queries.Handler;

public class AuthorizationQueryHandler(IAuthorizationService authorizationService, IMapper mapper) : ResponseHandler,
                                            IRequestHandler<GetRolesListQuery, Response<List<GetRoleResult>>>,
                                            IRequestHandler<GetRoleByIdQuery, Response<GetRoleResult>>
{
    private readonly IAuthorizationService _authorizationService = authorizationService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<List<GetRoleResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetIdentityRolesAsync();
        var result = _mapper.Map<List<GetRoleResult>>(roles);
        return Success(result);
    }

    public async Task<Response<GetRoleResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _authorizationService.GetIdentityRolesAsync();
        if (role is null)
            return NotFound<GetRoleResult>($"Role not found with id {request.Id}");
        var result = _mapper.Map<GetRoleResult>(role);
        return Success(result);
    }
}