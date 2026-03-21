using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class Department
    {
        public int DepartmentId {  get; set; }

        [MaxLength(60)]
        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>(); 
    }
}
