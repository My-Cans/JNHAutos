using FluentValidation;

namespace JNHAutos.Domain.Validators
{
    public class ContactValidator : AbstractValidator<ContactViewModel>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please enter your name.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Please enter your email.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Please enter your phone number.");

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Please enter a message.");
        }
    }
}
