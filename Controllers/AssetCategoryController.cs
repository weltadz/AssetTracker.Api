using AssetTracker.Api.Dto.AssetCategoryDto;
using AssetTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetCategoryController : ControllerBase
    {
        private readonly AssetCategoryService _assetCategoryService;

        public AssetCategoryController(AssetCategoryService assetCategoryService)
        {
            _assetCategoryService = assetCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssetCategory()
        {
            var assetCategories = await _assetCategoryService.GetAllAssetCategoryAsync();

            return Ok(new {AssetCategories = assetCategories});
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssetCategoryAsync(CreateAssetCategoryDto dto)
        {
            await _assetCategoryService.CreateAssetCategoryAsync(dto);
            return Ok(new { message = "Asset category successfully created" });
        }

        [HttpPatch("{assetCategoryId}")]
        public async Task<IActionResult> PatchAssetCategoryAsync(int assetCategoryId, PatchAssetCategoryDto dto)
        {
            await _assetCategoryService.PatchAssetCategoryAsync(assetCategoryId ,dto);
            return Ok(new { message = "Asset category successfully updated" });
        }

        [HttpDelete("{assetCategoryId}")]
        public async Task<IActionResult> DeleteAssetCategoryAsync(int assetCategoryId)
        {
            await _assetCategoryService.DeleteAssetCategoryAsync(assetCategoryId);
            return Ok(new { message = "Asset category successfully deleted" });
        }
    }
}
