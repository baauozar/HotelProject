using FluentValidation;
using HotelProject.UI.Dtos.AboutDto;

namespace HotelProject.UI.ValidationRules.AboutUsValidationRules
{
    public class UpdateAboutUsValidator:AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutUsValidator()
        {
            RuleFor(x => x.Title1).NotEmpty().WithMessage("Title1 is required.");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Title2 is required.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.RoomCount).GreaterThanOrEqualTo(0).WithMessage("Room count must be zero or a positive number.");
            RuleFor(x => x.StaffCount).GreaterThanOrEqualTo(0).WithMessage("Staff count must be zero or a positive number.");
            RuleFor(x => x.CustomerCount).GreaterThanOrEqualTo(0).WithMessage("Customer count must be zero or a positive number.");
            RuleFor(x => x.Title1).MaximumLength(100).WithMessage("Title1 max length is 100");
            RuleFor(x => x.Title2).MaximumLength(100).WithMessage("Title2 max length is 100");
            RuleFor(x => x.Content).MaximumLength(1000).WithMessage("Content max length is 1000");
        }
    }
}
