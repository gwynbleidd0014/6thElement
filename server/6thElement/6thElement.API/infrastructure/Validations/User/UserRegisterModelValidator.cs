using _6thElement.Application.Users;
using FluentValidation;

namespace _6thElement.API.infrastructure.Validations.User
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.Age)
                .NotEmpty()
                .GreaterThan(5)
                .LessThan(150);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(5)
                .MaximumLength(50); 

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(50);
        }
    }
}
