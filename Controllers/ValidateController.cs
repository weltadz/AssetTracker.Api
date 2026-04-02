using AssetTracker.Api.Dto.AuthDto;
using AssetTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly ValidateService _validateService;

        public ValidateController(ValidateService validateService)
        {
            _validateService = validateService;
        }

        [HttpPost]
        public async Task<IActionResult> ValidateUserAsync(ValidateDto dto)
        {
            await _validateService.ValidateUserAsync(dto);
            return Ok(new {message = "Successfully Login"});
        }
    }
}
