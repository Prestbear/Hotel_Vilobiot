using FluentValidation;
using Hotel_Vilobiot.DTO.Request;

namespace Hotel_Vilobiot.Validators;

public class ReservationValidator : AbstractValidator<ReserveReqeuest>
{
    public ReservationValidator()
    {
        RuleFor(x => x.CheckIn)
            .NotEmpty().WithMessage("CheckIn date is required!")
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("CheckIn date cannot be earlier than the current date!");
        RuleFor(x => x.CheckOut)
            .GreaterThanOrEqualTo(x => x.CheckIn).WithMessage("CheckOut date cannot be earlier than the CheckIn date!")
            .When(x => x.CheckOut != null);
    }
}