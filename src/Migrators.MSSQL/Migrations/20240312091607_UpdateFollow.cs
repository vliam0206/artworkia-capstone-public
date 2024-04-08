using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFollow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Account_AccountId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Account_FollowerId",
                table: "Follow");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "Follow",
                newName: "FollowedId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Follow",
                newName: "FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FollowerId",
                table: "Follow",
                newName: "IX_Follow_FollowedId");

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Budget",
                value: 69000.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Account_FollowedId",
                table: "Follow",
                column: "FollowedId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Account_FollowingId",
                table: "Follow",
                column: "FollowingId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Account_FollowedId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Account_FollowingId",
                table: "Follow");

            migrationBuilder.RenameColumn(
                name: "FollowedId",
                table: "Follow",
                newName: "FollowerId");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "Follow",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FollowedId",
                table: "Follow",
                newName: "IX_Follow_FollowerId");

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Budget",
                value: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Account_AccountId",
                table: "Follow",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Account_FollowerId",
                table: "Follow",
                column: "FollowerId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
