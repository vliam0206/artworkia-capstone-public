using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAIGenerated",
                table: "Artwork",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Artwork",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "IsAIGenerated", "Note" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAIGenerated",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Artwork");
        }
    }
}
