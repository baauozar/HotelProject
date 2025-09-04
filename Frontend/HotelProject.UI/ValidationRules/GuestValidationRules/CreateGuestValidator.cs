using FluentValidation;
using HotelProject.UI.Dtos.GuestDto;

namespace HotelProject.UI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.GuestName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.GuestSurname).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.GuestCity).NotEmpty().WithMessage("City  is required.");
            RuleFor(x => x.GuestName).MinimumLength(2).WithMessage("First name must be at least 2 characters long.");
            RuleFor(x => x.GuestSurname).MinimumLength(2).WithMessage("Surname must be at least 2 characters long.");
            RuleFor(x => x.GuestCity).MinimumLength(2).WithMessage("City must be at least 2 characters long.");

            RuleFor(x => x.GuestName).MaximumLength(20).WithMessage("Name max length is 20");
            RuleFor(x => x.GuestSurname).MaximumLength(20).WithMessage("Surname max length is 20");
            RuleFor(x => x.GuestCity).MaximumLength(20).WithMessage("City max length is 20.");

            RuleFor(x => x.GuestName)
          .Matches("^[a-zA-Z ]+$").WithMessage("Guest name must contain only letters and spaces");

            RuleFor(x => x.GuestSurname)
          .Matches("^[a-zA-Z ]+$").WithMessage("Guest Surname must contain only letters and spaces");

        }
    }
}
