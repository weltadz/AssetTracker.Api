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

        //Create Location
        [HttpPost]
        public async Task<IActionResult> CreateAssetLocationAsync(CreateAssetLocationDto dto)
        {
            await _assetLocationService.CreateAssetLocationAsync(dto);
            return Ok(new { message = "Location successfully created" });
        }

        //Get all Location
        [HttpGet]
        public async Task<IActionResult> GetAllAssetLocationAsync()
        {
            var locations = await _assetLocationService.GetAllAssetLocationAsync();

            return Ok(new { Locations = locations });
        }

        //Patch Location
        [HttpPatch("{assetLocationId}")]
        public async Task<IActionResult> PatchAssetLocationAsync(int assetLocationId, PatchAssetLocationDto dto)
        {
            await _assetLocationService.PatchAssetLocationAsync(assetLocationId, dto);
            return Ok(new { message = "Location updated successfully" });
        }

        //Delete Location
        [HttpDelete("{assetLocationId}")]
        public async Task<IActionResult> DeleteAssetLocationAsync(int assetLocationId)
        {
            await _assetLocationService.DeleteAssetLocationAsync(assetLocationId);
            return Ok(new { message = "Location successfully deleted" });
        }
    }
}
