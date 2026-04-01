using AssetTracker.Api.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Api.Data
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Category
            modelBuilder.Entity<AssetCategory>()
                .HasMany(ac => ac.Assets)
                .WithOne(a => a.AssetCategory)
                .HasForeignKey(a => a.AssetCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //Location
            modelBuilder.Entity<AssetLocation>()
                .HasMany(l => l.Assets)
                .WithOne(a => a.AssetLocation)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            //Status
            modelBuilder.Entity<AssetStatus>()
                .HasMany(s => s.Assets)
                .WithOne(a => a.Status)
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<AssetStatus> AssetStatuses { get; set; }

        public DbSet<AssetLocation> AssetLocations { get; set; }

        public DbSet<AssetCategory> AssetCategories { get; set; }
    }
}
