
using AssetTracker.Api.Data;
using AssetTracker.Api.Services.Interfaces;

namespace AssetTracker.Api.Services
{
    public class AssetLocationService : IAssetLocationService
    {
        private readonly AssetDbContext _dbContext;

        public AssetLocationService(AssetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
