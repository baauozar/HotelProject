using FluentValidation;
using HotelProject.UI.Dtos.RoomDto;

namespace HotelProject.UI.ValidationRules.RoomValidationRules
{
    public class UpdateRoomValidator:AbstractValidator<UpdateRoomDto>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.RoomNumber).NotEmpty().WithMessage("Room number is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description max length is 500.");
            RuleFor(x => x.RoomNumber)
          .Matches("^[a-zA-Z0-9]+$").WithMessage("Room number must contain only letters and numbers");
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .LessThanOrEqualTo(10000).WithMessage("Price must be less than or equal to 10,000.");
            RuleFor(x => x.Title).Length(2, 100).WithMessage("Title must be between 2 and 100 characters long.");
            RuleFor(x => x.BathCount).Length(2, 100).WithMessage("Title must be between 2 and 100 characters long.");
            RuleFor(x => x.BedCount).Length(2, 100).WithMessage("Title must be between 2 and 100 characters long.");
        }
    }
}
