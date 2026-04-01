using AssetTracker.Api.Dto.AssetLocationDto;
using AssetTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetLocationController : ControllerBase
    {
        private readonly AssetLocationService _assetLocationService;

        public AssetLocationController(AssetLocationService assetLocationService)
        {
            _assetLocationService = assetLocationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssetLocationAsync(CreateAssetLocationDto dto)
        {
            await _assetLocationService.CreateAssetLocationAsync(dto);
            return Ok(new { message = "Location successfully created" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssetLocationAsync()
        {
            var locations = await _assetLocationService.GetAllAssetLocationAsync();

            return Ok(new { Locations = locations });
        }

        [HttpPatch]
        public async Task<IActionResult> PatchAssetLocationAsync(int assetLocationId, PatchAssetLocationDto dto)
        {
            await _assetLocationService.PatchAssetLocationAsync(assetLocationId, dto);
            return Ok(new { message = "Location updated successfully" });
        }
    }
}
