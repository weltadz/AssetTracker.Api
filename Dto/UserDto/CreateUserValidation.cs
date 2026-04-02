using FluentValidation;

namespace AssetTracker.Api.Dto.UserDto
{
    public class CreateUserValidation : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Empty field is not allowed");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Empty field is not allowed");
        }
    }
}
