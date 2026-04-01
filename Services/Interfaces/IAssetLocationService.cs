using AssetTracker.Api.Dto.AssetLocationDto;

namespace AssetTracker.Api.Services.Interfaces
{
    public interface IAssetLocationService
    {
        Task<List<GetAllAssetLocationDto>> GetAllAssetLocationAsync();
    }
}
