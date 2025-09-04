using FluentValidation;
using HotelProject.UI.Dtos.Service;

namespace HotelProject.UI.ValidationRules.ServiceValidationRules
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Title).Length(2, 100).WithMessage("Title must be between 2 and 100 characters long.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description max length is 500.");
            RuleFor(x => x.ServiceIcon).NotEmpty().WithMessage("Icon is required.");
        }
    }
}
