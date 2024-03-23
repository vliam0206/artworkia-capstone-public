using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class EditNotificationSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificatedId",
                table: "Notification");

            migrationBuilder.AddColumn<Guid>(
                name: "ReferencedAccountId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReferencedArtworkId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferencedAccountId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ReferencedArtworkId",
                table: "Notification");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificatedId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
