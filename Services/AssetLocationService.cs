using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.AssetLocationDto;
using Microsoft.EntityFrameworkCore;
using AssetTracker.Api.Model;

namespace AssetTracker.Api.Services
{
    public class AssetLocationService
    {
        private readonly AssetDbContext _dbContext;

        public AssetLocationService(AssetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create location
        public async Task CreateAssetLocationAsync(CreateAssetLocationDto dto)
        {
            var exist = await _dbContext.AssetLocations
                .FirstOrDefaultAsync(al => al.AssetLocationName == dto.AssetLocationName);

            if(exist != null)
            {
                throw new InvalidOperationException("Location already exists");
            }

            exist = new AssetLocation
            {
                AssetLocationName = dto.AssetLocationName
            };

            await _dbContext.AssetLocations.AddAsync(exist);
            await _dbContext.SaveChangesAsync();
        }

        //Get all location
        public async Task<List<GetAllAssetLocationDto>> GetAllAssetLocationAsync()
        {
            var location = await _dbContext.AssetLocations
                .Select(al => new GetAllAssetLocationDto
                {
                    AssetLocationName = al.AssetLocationName

                }).ToListAsync();

            return location;
        }

        //Patch location
        public async Task PatchAssetLocationAsync(int assetLocationId, PatchAssetLocationDto dto)
        {
            var location = await _dbContext.AssetLocations
                .FirstOrDefaultAsync(al => al.AssetLocationId == assetLocationId);

            if(location == null)
            {
                throw new KeyNotFoundException("Location does not exists");
            }

            if(location.AssetLocationName == dto.AssetLocationName)
            {
                throw new InvalidOperationException("Location already exists");
            }

            location.AssetLocationName = string.IsNullOrWhiteSpace(dto.AssetLocationName) ?
                location.AssetLocationName : dto.AssetLocationName;

            await _dbContext.SaveChangesAsync();
        }
    }
}
