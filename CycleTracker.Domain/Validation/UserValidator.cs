using CycleTracker.Domain.Entity;
using FluentValidation;

namespace CycleTracker.Domain.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(250);

        RuleFor(c => c.Senha)
            .NotEmpty()
            .MinimumLength(8);
    }
}