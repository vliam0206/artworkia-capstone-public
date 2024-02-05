using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArtworkAndReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Artwork",
                newName: "State");

            migrationBuilder.AlterColumn<Guid>(
                name: "TargetId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Reason", "ReportEntity", "ReportType", "State", "TargetId" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 27, 15, 40, 28, 901, DateTimeKind.Local), "this is sexual harrasment", 2, 0, 0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1") },
                    { new Guid("7d580000-c214-88a4-0d90-08dc2662aa73"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 29, 15, 40, 28, 901, DateTimeKind.Local), "Disallowed content", 2, 4, 0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1") },
                    { new Guid("7d580000-c214-88a4-4a40-08dc26620bdc"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 27, 15, 40, 28, 901, DateTimeKind.Local), "Not suitable", 2, 4, 0, new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9") },
                    { new Guid("7d580000-c214-88a4-4a40-08dc26621bdc"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 28, 15, 40, 28, 901, DateTimeKind.Local), "This is spam", 2, 2, 0, new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9") },
                    { new Guid("7d580000-c214-88a4-7151-08dc26627e8b"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 28, 15, 40, 28, 901, DateTimeKind.Local), "Disallowed content", 2, 5, 0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1") },
                    { new Guid("7d580000-c214-88a4-a111-08dc2662267b"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 27, 15, 40, 28, 901, DateTimeKind.Local), "Abuse of platform", 2, 0, 2, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1") },
                    { new Guid("7d580000-c214-88a4-eb45-08dc266225b8"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 7, 15, 40, 28, 901, DateTimeKind.Local), "Inappropriate content", 2, 3, 1, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-0d90-08dc2662aa73"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-4a40-08dc26620bdc"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-4a40-08dc26621bdc"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-7151-08dc26627e8b"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-a111-08dc2662267b"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-eb45-08dc266225b8"));

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Artwork",
                newName: "Status");

            migrationBuilder.AlterColumn<Guid>(
                name: "TargetId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
