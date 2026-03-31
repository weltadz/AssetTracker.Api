using AssetTracker.Api.Dto.AssetCategoryDto;
using AssetTracker.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetCategoryController : ControllerBase
    {
        private readonly IAssetCategoryService _assetCategoryService;

        public AssetCategoryController(IAssetCategoryService assetCategoryService)
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
    }
}
