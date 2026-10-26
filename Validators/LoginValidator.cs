using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace Hotel_Vilobiot.Validators;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress()
            .WithMessage("Invalid Email").NotEmpty().WithMessage("Email required");
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password required")
            .MinimumLength(8)
            .WithMessage("Password should be at least 8 characters");
    }
}