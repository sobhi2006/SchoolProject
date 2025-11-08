using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handler;

public class UserCommandHandler(IMapper mapper, UserManager<User> userManager) : ResponseHandler,
                             IRequestHandler<AddUserCommand, Response<string>>,
                             IRequestHandler<UpdateUserCommand, Response<string>>,
                             IRequestHandler<DeleteUserCommand, Response<string>>,
                             IRequestHandler<ChangePasswordCommand, Response<string>>
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("Student not found");

        var userName = await _userManager.Users.AnyAsync(u => u.UserName == request.UserName && u.Id != request.Id.ToString());
        if (userName)
            return BadRequest<string>("userName is existed");

        var UserMapped = _mapper.Map(request, User);
        var result = await _userManager.UpdateAsync(UserMapped);
        return !result.Succeeded ? BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description))) : Success<string>("Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("User not found");

        var result = await _userManager.DeleteAsync(User);
        if (!result.Succeeded)
            return BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description)));

        return Success<string>("Deleted Successfully");
    }

    public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("User not found");

        var result = await _userManager.ChangePasswordAsync(User, request.OldPassword, request.NewPassword);

        if (!result.Succeeded)
            return BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description)));

        return Success<string>("Change password Successfully");
    }

    async Task<Response<string>> IRequestHandler<AddUserCommand, Response<string>>.Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is not null)
            return BadRequest<string>("Email is existed");

        var userName = await _userManager.FindByNameAsync(request.UserName);
        if (userName is not null)
            return BadRequest<string>("userName is existed");

        var UserMapped = _mapper.Map<User>(request);
        var CreatedUser = await _userManager.CreateAsync(UserMapped, request.Password);
        if (!CreatedUser.Succeeded)
            return BadRequest<string>(string.Join("\n", CreatedUser.Errors.Select(e => e.Description)));

        return Created("Add User Successfully");
    }
}