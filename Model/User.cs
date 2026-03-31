using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(60)]
        public string UserName { get; set; } = null!;

        [MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}
