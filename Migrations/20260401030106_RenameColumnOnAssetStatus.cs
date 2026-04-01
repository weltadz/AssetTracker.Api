using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracker.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnOnAssetStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "AssetStatuses",
                newName: "AssetStatusName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssetStatusName",
                table: "AssetStatuses",
                newName: "StatusName");
        }
    }
}
