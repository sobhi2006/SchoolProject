using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Features.Users.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Queries.Handler;

public class GetUserHandler(IMapper mapper, UserManager<User> userManager) : ResponseHandler,
                        IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserResponse>>,
                        IRequestHandler<GetUserByIdQuery, Response<GetUserResponse>>

{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<PaginatedResult<GetUserResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.AsQueryable();

        var UsersMapped = await _mapper.ProjectTo<GetUserResponse>(users)
                                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return UsersMapped;
    }

    public async Task<Response<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
            return NotFound<GetUserResponse>($"User not not found with Id = {request.Id}");

        var userMapper = _mapper.Map<GetUserResponse>(user);
        return Success(userMapper);
    }
}