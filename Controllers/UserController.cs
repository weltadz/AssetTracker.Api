using AssetTracker.Api.Dto.UserDto;
using AssetTracker.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto dto)
        {
            await _userService.CreateUserAsync(dto);
            return Ok(new {message = "User successfully created"}) ;
        }
    }
}
