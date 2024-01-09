using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class EditThumbnailOfArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCover",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Artwork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Artwork");

            migrationBuilder.AddColumn<bool>(
                name: "IsCover",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
