using AssetTracker.Api.Data;

namespace AssetTracker.Api.Services
{
    public class AssetService
    {
        private readonly AssetDbContext _assetDbContext;

        public AssetService(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
        }
    }
}
