using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.FullName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");
    }
}