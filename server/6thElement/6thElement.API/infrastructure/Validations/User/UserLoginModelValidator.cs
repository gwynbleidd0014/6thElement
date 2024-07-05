using _6thElement.Application.Users;
using FluentValidation;

namespace _6thElement.API.infrastructure.Validations.User;

public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
{
    public UserLoginModelValidator()
    {

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
