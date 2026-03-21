using Microsoft.EntityFrameworkCore;
using AssetTracker.Api.Model;

namespace AssetTracker.Api.Data 
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Department
            modelBuilder.Entity<Department>()
                .HasMany(dep => dep.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.EmployeeCode)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Assets)
                .WithOne(ast => ast.User)
                .HasForeignKey(ast => ast.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AssetAssignments)
                .WithOne(assign => assign.User)
                .HasForeignKey(assign => assign.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Asset
            modelBuilder.Entity<Asset>()
                .HasIndex(ast => ast.AssetTag)
                .IsUnique();

            modelBuilder.Entity<Asset>()
                .HasMany(ast => ast.AssetAssignments)
                .WithOne(assign => assign.Asset)
                .HasForeignKey(assign => assign.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            //Asset Category
            modelBuilder.Entity<AssetCategories>()
                .HasMany(astc => astc.Assets)
                .WithOne(ast => ast.AssetCategories)
                .HasForeignKey(ast => ast.AssetCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //Asset Status
            modelBuilder.Entity<AssetStatus>()
                .HasMany(asts => asts.Assets)
                .WithOne(ast => ast.AssetStatus)
                .HasForeignKey(ast => ast.AssetStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            //Asset Location
            modelBuilder.Entity<AssetLocation>()
                .HasMany(astl => astl.Assets)
                .WithOne(ast => ast.AssetLocation)
                .HasForeignKey(ast => ast.AssetLocationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
