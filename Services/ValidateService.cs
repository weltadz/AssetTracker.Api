using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.AuthDto;
using AssetTracker.Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Api.Services
{
    public class ValidateService
    {
        private readonly AssetDbContext _assetDbContext;

        public ValidateService(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
        }

        public async Task<User> ValidateUserAsync(LoginDto dto)
        {
            var user = await _assetDbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == dto.Username);

            if(user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var passwordVerify = new PasswordHasher<User>();

            var result = passwordVerify.VerifyHashedPassword(user, user.Password, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new InvalidOperationException("Invalid Credentials");
            }

            return user;
        }
    }
}
