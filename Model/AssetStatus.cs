namespace AssetTracker.Api.Model
{
    public class AssetStatus
    {
        public int AssetStatusId { get; set; }

        public string StatusName { get; set; } = null!;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
