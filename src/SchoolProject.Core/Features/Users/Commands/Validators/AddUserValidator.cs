using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validators;

public class AddUserValidator : AbstractValidator<AddUserCommand>
{
    public AddUserValidator()
    {
        RuleFor(u => u.FullName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password).WithMessage("Confirm Password must match Password");
    }
}