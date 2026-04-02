using AssetTracker.Api.Dto.AuthDto;

namespace AssetTracker.Api.Services
{
    public class LoginService
    {
        private readonly ValidateService _validateService;
        private readonly JwtService _jwtService;

        public LoginService(ValidateService validateService, JwtService jwtService)
        {
            _validateService = validateService;
            _jwtService = jwtService;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _validateService.ValidateUserAsync(dto);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = _jwtService.GenerateToken(user.UserId.ToString(), user.UserName);

            return token;
        }
    }
}
