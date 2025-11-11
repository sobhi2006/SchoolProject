using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator;

public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleCommand>
{
    public UpdateUserRoleValidator()
    {
        RuleFor(r => r.UserId)
            .NotNull().WithMessage("is required")
            .NotEmpty().WithMessage("must not empty");

        RuleFor(r => r.OldRole)
            .NotNull().WithMessage("is required")
            .NotEmpty().WithMessage("must not empty");

        RuleFor(r => r.NewRole)
            .NotNull().WithMessage("is required")
            .NotEmpty().WithMessage("must not empty");
    }
}