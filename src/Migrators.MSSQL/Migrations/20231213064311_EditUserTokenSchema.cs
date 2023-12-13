using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTokenSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserToken_JwtId",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserToken_RefreshToken",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "JwtId",
                table: "UserToken");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "UserToken",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "ATid",
                table: "UserToken",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "UserToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RTid",
                table: "UserToken",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_ATid",
                table: "UserToken",
                column: "ATid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RTid",
                table: "UserToken",
                column: "RTid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserToken_ATid",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserToken_RTid",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "ATid",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "RTid",
                table: "UserToken");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "UserToken",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "JwtId",
                table: "UserToken",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_JwtId",
                table: "UserToken",
                column: "JwtId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RefreshToken",
                table: "UserToken",
                column: "RefreshToken",
                unique: true);
        }
    }
}
