using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class User
    {
        public int UserId {  get; set; }

        [MaxLength(12)]
        public string EmployeeCode { get; set; } = null!;

        [MaxLength(60)]
        public string FirstName { get; set; } = null!;

        [MaxLength(60)]
        public string LastName { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public bool IsActive {  get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();

        public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();

    }
}
