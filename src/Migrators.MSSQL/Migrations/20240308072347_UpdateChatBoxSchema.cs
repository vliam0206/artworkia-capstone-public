using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatBoxSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"));

            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1295c"));

            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1296c"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatBox",
                columns: new[] { "Id", "AccountId_1", "AccountId_2" },
                values: new object[,]
                {
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2") },
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1295c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1") },
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1296c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2") }
                });
        }
    }
}
