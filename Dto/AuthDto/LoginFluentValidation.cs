using FluentValidation;

namespace AssetTracker.Api.Dto.AuthDto
{
    public class LoginFluentValidation : AbstractValidator<LoginDto>
    {
        public LoginFluentValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Fields must not be empty");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Fields must not be empty");
        }
    }
}
