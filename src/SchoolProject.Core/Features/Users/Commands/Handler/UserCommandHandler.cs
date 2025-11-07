using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handler;

public class UserCommandHandler(IMapper mapper, UserManager<User> userManager) : ResponseHandler,
                             IRequestHandler<AddUserCommand, Response<string>>,
                             IRequestHandler<UpdateUserCommand, Response<string>>
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("Student not found");

        var UserMapped = _mapper.Map(request, User);
        var result = await _userManager.UpdateAsync(UserMapped);
        return !result.Succeeded ? BadRequest<string>("Not Updated") : Success<string>("Updated Successfully");
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
            return BadRequest<string>("Failed to add user");

        return Created("Add User Successfully");
    }
}