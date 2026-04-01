using FluentValidation;

namespace AssetTracker.Api.Dto.AssetLocationDto
{
    public class CreateAssetLocationValidation : AbstractValidator<CreateAssetLocationDto>
    {
        public CreateAssetLocationValidation()
        {
            RuleFor(x => x.AssetLocationName)
                .NotEmpty()
                .WithMessage("Asset location name field is required");
        }
    }
}
