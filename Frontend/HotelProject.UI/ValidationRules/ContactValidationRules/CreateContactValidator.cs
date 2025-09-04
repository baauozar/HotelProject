using FluentValidation;
using HotelProject.UI.Dtos.ContactDto;

namespace HotelProject.UI.ValidationRules.ContactValidationRules
{
    public class CreateContactValidator:AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is required.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Subject must be at least 2 characters long.");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Message must be at least 10 characters long.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name max length is 50");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Subject max length is 100");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("Message max length is 500.");
            RuleFor(x => x.Name)
          .Matches("^[a-zA-Z ]+$").WithMessage("Name must contain only letters and spaces");
            RuleFor(x => x.Mail)
          .EmailAddress().WithMessage("Invalid email format");
        }
    }
}
