using FluentValidation;

namespace AssetTracker.Api.Dto.AuthDto
{
    public class ValidateFluentValidation : AbstractValidator<ValidateDto>
    {
        public ValidateFluentValidation()
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
