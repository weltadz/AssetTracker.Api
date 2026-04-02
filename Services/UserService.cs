using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.UserDto;
using AssetTracker.Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Api.Services
{
    public class UserService
    {
        private readonly AssetDbContext _assetDbContext;

        public UserService(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
        }

        //Create user
        public async Task CreateUserAsync(CreateUserDto dto)
        {
            var user = await _assetDbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == dto.UserName);

            if(user != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            var passwordHasher = new PasswordHasher<User>();

            user = new User
            {
                UserName = dto.UserName
            };

            user.Password = passwordHasher.HashPassword(user, dto.Password);

            await _assetDbContext.Users.AddAsync(user);
            await _assetDbContext.SaveChangesAsync();

        }
    }
}
