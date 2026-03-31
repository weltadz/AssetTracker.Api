using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class Asset
    {
        public int AssetId { get; set; }

        [MaxLength(6)]
        public string AssetTag { get; set; } = null!;

        [MaxLength(60)]
        public string AssetName { get; set; } = null!;

        public int AssetCategoryId { get; set; }
        public AssetCategory AssetCategory { get; set; } = null!;

        public int LocationId { get; set; }
        public AssetLocation Location { get; set; } = null!;

        public int StatusId { get; set; }
        public AssetStatus Status { get; set; } = null!;
    }
}
