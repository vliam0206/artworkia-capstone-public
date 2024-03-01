using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProposalAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concept",
                table: "ProposalAsset");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProposalAsset");

            migrationBuilder.RenameColumn(
                name: "AssetLocation",
                table: "ProposalAsset",
                newName: "ProposalAssetName");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProposalAsset",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ProposalAsset",
                type: "int",
                maxLength: 150,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProposalAsset");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProposalAsset");

            migrationBuilder.RenameColumn(
                name: "ProposalAssetName",
                table: "ProposalAsset",
                newName: "AssetLocation");

            migrationBuilder.AddColumn<string>(
                name: "Concept",
                table: "ProposalAsset",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Version",
                table: "ProposalAsset",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
