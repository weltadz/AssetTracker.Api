using FluentValidation;

namespace AssetTracker.Api.Dto.AssetCategoryDto
{
    public class CreateAssetCategoryValidation : AbstractValidator<CreateAssetCategoryDto>
    {
        public CreateAssetCategoryValidation()
        {
            RuleFor(x => x.AssetCategoryName)
                .NotEmpty()
                .WithMessage("Asset category name field is required");
        }
    }
}
