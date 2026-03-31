using AssetTracker.Api.Dto.AssetCategoryDto;

namespace AssetTracker.Api.Services.Interfaces
{
    public interface IAssetCategoryService
    {
        Task<List<GetAllAssetCategoryDto>> GetAllAssetCategoryAsync();

        Task CreateAssetCategoryAsync(CreateAssetCategoryDto dto);
    }
}
