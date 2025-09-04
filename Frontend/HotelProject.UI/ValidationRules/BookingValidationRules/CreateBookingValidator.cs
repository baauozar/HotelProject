using FluentValidation;
using HotelProject.UI.Dtos.BookingDto;

namespace HotelProject.UI.ValidationRules.BookingValidationRules
{
    public class CreateBookingValidator:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.Checkin).NotEmpty().WithMessage("Check-in date is required.");
            RuleFor(x => x.CheckOut).NotEmpty().WithMessage("Check-out date is required.");
            RuleFor(x => x.AdultCount).NotEmpty().WithMessage("Adult count is required.");
            RuleFor(x => x.RoomCount).NotEmpty().WithMessage("Room count is required.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Email must be at least 5 characters long.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name max length is 50");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Email max length is 100");
            RuleFor(x => x.SpecialRequest).MaximumLength(500).WithMessage("Special request max length is 500.");
            RuleFor(x => x.Descripstion).MaximumLength(500).WithMessage("Description max length is 500.");
            RuleFor(x => x.Name)
          .Matches("^[a-zA-Z ]+$").WithMessage("Name must contain only letters and spaces");
            RuleFor(x => x.Mail)
          .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.CheckOut)
          .GreaterThanOrEqualTo(x => x.Checkin.AddDays(1))
          .WithMessage("Check-out date must be at least one day after check-in date.");
        }
    }
}
