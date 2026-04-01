using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class AssetLocation
    {
        public int AssetLocationId { get; set; }

        [MaxLength(60)]
        public string AssetLocationName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
