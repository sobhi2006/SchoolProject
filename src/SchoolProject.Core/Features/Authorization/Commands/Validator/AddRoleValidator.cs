using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator;

public class AddRoleValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleValidator(IAuthorizationService authorizationService)
    {
        RuleFor(r => r.RoleName)
            .NotNull().WithMessage("RoleName is required")
            .NotEmpty().WithMessage("RoleName must not empty");

        RuleFor(r => r.RoleName)
            .MustAsync(async (key, ct) => !await authorizationService.IsRoleExist(key))
            .WithMessage("Role is Exist");
    }
}