using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class Asset
    {
        public int AssetId { get; set; }

        [MaxLength(12)]
        public string AssetTag { get; set; } = null!;

        [MaxLength(60)]
        public string AssetName { get; set; } = null!;

        public int AssetCategoryId { get; set; }
        public AssetCategory AssetCategory { get; set; } = null!;

        public int AssetStatusId { get; set; }
        public AssetStatus AssetStatus { get; set; } = null!;

        public int AssetLocationId { get; set; }
        public AssetLocation AssetLocation { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime PurchasedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();
    }
}
