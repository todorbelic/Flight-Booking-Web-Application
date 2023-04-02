using FluentValidation;
using XMLApp.DTO;

namespace XMLApp.Validators
{
    public class RegistrationDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegistrationDTOValidator() {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 100).WithMessage("Please write your first name");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 100).WithMessage("Please write your last name.");
            RuleFor(x => x.Role).NotEmpty().Matches("(?:CUSTOMER|ADMIN)").WithMessage("Role doesn't match any of the following: CUSTOMER, ADMIN.");
            RuleFor(x => x.Email).NotEmpty().Length(8, 50).Matches(@"([a-zA-Z]+)(.[a-zA-Z]+)*@([a-zA-Z]+)\.(.[a-zA-Z]+)*").WithMessage("Email incorrect!");
            RuleFor(x => x.Password).NotEmpty().Length(8, 20).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$").WithMessage("Password incorrect! It should contain at least one capital letter, at least one number and at least 8 characters.");
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
