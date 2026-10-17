using FluentValidation;
using Hotel_Vilobiot.DTO.Request;

namespace Hotel_Vilobiot.Validators;

public class EditGuestValidator : AbstractValidator<EditGuestRequest>
{
    public EditGuestValidator()
    {
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password required").MinimumLength(8)
            .WithMessage("Password should be at least 8 characters");
        
        RuleFor(x => x.Age)
            .InclusiveBetween(10, 100)
            .WithMessage("Age must be between 10 and 100");
    }
}