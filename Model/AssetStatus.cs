using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class AssetStatus
    {
        public int AssetStatusId { get; set; }

        [MaxLength(60)]
        public string AssetStatusName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
