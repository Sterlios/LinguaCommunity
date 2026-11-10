using FluentValidation;
using LinguaCommunity.Application.Dtos.Requests;

namespace LinguaCommunity.Api.Validators;

public class RegisterValidator: AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.PasswordConfirmation)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");

        RuleFor(x => x.Nickname)
            .NotEmpty().WithMessage("Nickname is required.");
    }
}