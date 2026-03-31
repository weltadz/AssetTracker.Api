namespace AssetTracker.Api.Model
{
    public class AssetLocation
    {
        public int AssetLocationId { get; set; }

        public string LocationName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
