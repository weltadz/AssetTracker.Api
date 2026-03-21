using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class AssetAssignment
    {
        public int AssetAssignmentId { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime AssignedDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
