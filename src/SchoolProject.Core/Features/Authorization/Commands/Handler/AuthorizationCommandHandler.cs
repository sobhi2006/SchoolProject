using System.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Handler;

public class AuthorizationCommandHandler(IAuthorizationService authorizationService, UserManager<User> userManager) 
                                         : ResponseHandler,
                                           IRequestHandler<AddRoleCommand, Response<string>>,
                                           IRequestHandler<UpdateRoleCommand, Response<string>>,
                                           IRequestHandler<DeleteRoleCommand, Response<string>>,
                                           IRequestHandler<UpdateUserRoleCommand, Response<string>>
{
    private readonly IAuthorizationService _authorizationService = authorizationService;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationService.AddRoleAsync(request.RoleName);
        return result ? Created<string>(null) : BadRequest<string>("Failed to add role"); 
    }

    public async Task<Response<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationService.UpdateRoleAsync(request.Id, request.RoleName);
        return result ? Created<string>(null) : BadRequest<string>("Failed to Update role");
    }

    public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationService.DeleteRoleAsync(request.Id);
        return result ? Deleted<string>() : BadRequest<string>("Failed to Delete role");
    }

    public async Task<Response<string>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
            return NotFound<string>("User not found");

        var OldRole = await _authorizationService.GetIdentityRoleByIdAsync(request.OldRole);
        if (OldRole is null)
            return NotFound<string>("OldRole not found");

        var NewRole = await _authorizationService.GetIdentityRoleByIdAsync(request.NewRole);
        if (NewRole is null)
            return NotFound<string>("NewRole not found");

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        try
        {
            var removeResult = await _userManager.RemoveFromRoleAsync(user, OldRole.Name);
            if (!removeResult.Succeeded)
                return BadRequest<string>("Failed to update user role");

            var addResult = await _userManager.AddToRoleAsync(user, NewRole.Name);
            if (!addResult.Succeeded)
                return BadRequest<string>("Failed to update user role");
        }
        catch (Exception ex)
        {
            return BadRequest<string>(ex.Message);
        }
        transaction.Complete();
        return Success("user role updated successfully");
    }
}