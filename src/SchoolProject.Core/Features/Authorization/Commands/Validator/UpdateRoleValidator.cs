using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(r => r.Id)
            .NotNull().WithMessage("Id is required")
            .NotEmpty().WithMessage("Id must not empty");

        RuleFor(r => r.RoleName)
            .NotNull().WithMessage("RoleName is required")
            .NotEmpty().WithMessage("RoleName must not empty");
    }
}
