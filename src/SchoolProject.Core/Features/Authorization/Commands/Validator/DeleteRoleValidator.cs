using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator;

public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleValidator(IAuthorizationService authorizationService)
    {
        RuleFor(r => r.Id)
            .NotNull().WithMessage("Id is required")
            .NotEmpty().WithMessage("Id must not empty");

        RuleFor(r => r.Id)
            .MustAsync(async (key, ct) => await authorizationService.IsRoleExist(key))
            .WithMessage("Role is not Exist");
    }
}