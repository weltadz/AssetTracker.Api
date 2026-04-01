using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.AssetCategoryDto;
using AssetTracker.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AssetTracker.Api.Model;

namespace AssetTracker.Api.Services
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly AssetDbContext _dbContext;

        public AssetCategoryService(AssetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get all categories
        public async Task<List<GetAllAssetCategoryDto>> GetAllAssetCategoryAsync()
        {
            return await _dbContext.AssetCategories
                .Select(ac => new GetAllAssetCategoryDto
                {
                    AssetCategoryId = ac.AssetCategoryId,
                    AssetCategoryName = ac.AssetCategoryName

                }).ToListAsync();
        }

        //Create Category
        public async Task CreateAssetCategoryAsync(CreateAssetCategoryDto dto)
        {
            var exist = await _dbContext.AssetCategories
                .FirstOrDefaultAsync(ac => ac.AssetCategoryName == dto.AssetCategoryName);

            if(exist != null)
            {
                throw new InvalidOperationException("Category already exist");
            }

            exist = new AssetCategory
            {
                AssetCategoryName = dto.AssetCategoryName
            };

            await _dbContext.AssetCategories.AddAsync(exist);
            await _dbContext.SaveChangesAsync();
        }

        //Patch Category
        public async Task PatchAssetCategoryAsync(int assetCategoryId, PatchAssetCategoryDto dto)
        {
            var category = await _dbContext.AssetCategories
                .FirstOrDefaultAsync(c => c.AssetCategoryId == assetCategoryId);

            if(category == null)
            {
                throw new KeyNotFoundException("Asset category does not exists");
            }

            category.AssetCategoryName = string.IsNullOrWhiteSpace(dto.AssetCategoryName) ? category.AssetCategoryName : dto.AssetCategoryName;

            await _dbContext.SaveChangesAsync();
        }

        //Delete Category
        public async Task DeleteAssetCategoryAsync(int assetCategoryId)
        {
            var category = await _dbContext.AssetCategories
                .FirstOrDefaultAsync(c => c.AssetCategoryId == assetCategoryId);

            if(category == null)
            {
                throw new KeyNotFoundException("Asset category does not exists");
            }

            _dbContext.AssetCategories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
