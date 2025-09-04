using FluentValidation;
using HotelProject.UI.Model.Staff;

namespace HotelProject.UI.ValidationRules.StaffValidationRules
{
    public class CreateStaffValidator:AbstractValidator<AddStaffViewModel>
    {
        public CreateStaffValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Position is required.");
            RuleFor(x => x.Name).Length(2, 100).WithMessage("Name must be between 2 and 100 characters long.");
          
        }
    }
}
