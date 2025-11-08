using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validators;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(u => u.Id)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.OldPassword)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.NewPassword)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.ConfirmedPassword)
                .Equal(u => u.NewPassword).WithMessage("Confirm Password must match Password");
    }
}