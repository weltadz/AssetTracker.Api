using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Dto.DepartmentDto
{
    public class CreateDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; } = null!;
    }
}
