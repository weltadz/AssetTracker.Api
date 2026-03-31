namespace AssetTracker.Api.Model
{
    public class AssetCategory
    {
        public int AssetCategoryId { get; set; }

        public string AssetCategoryName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>(); 
    }
}
