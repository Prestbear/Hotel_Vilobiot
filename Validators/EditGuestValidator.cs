using FluentValidation;
using Hotel_Vilobiot.DTO.Request;

namespace Hotel_Vilobiot.Validators;

public class EditGuestValidator : AbstractValidator<EditGuestRequest>
{
    public EditGuestValidator()
    {
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password required")
            .MinimumLength(8)
            .WithMessage("Password should be at least 8 characters");
        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18)
            .WithMessage("Age must be at least 18");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Full name required");
    }
}