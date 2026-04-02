using AssetTracker.Api.Dto.AuthDto;
using AssetTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            var token = await _loginService.LoginAsync(dto);
            return Ok(new { tokens = token });
        }
    }
}
