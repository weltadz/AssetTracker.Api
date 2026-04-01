using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracker.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnOnAssetLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "AssetLocations",
                newName: "AssetLocationName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssetLocationName",
                table: "AssetLocations",
                newName: "LocationName");
        }
    }
}
