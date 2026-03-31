using System.ComponentModel.DataAnnotations;

namespace AssetTracker.Api.Model
{
    public class AssetCategory
    {
        public int AssetCategoryId { get; set; }

        [MaxLength(60)]
        public string AssetCategoryName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>(); 
    }
}
