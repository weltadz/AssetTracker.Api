using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        [MaxLength(60)]
        public string RoleName { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
