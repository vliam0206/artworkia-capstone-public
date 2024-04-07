using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class EditTransactionHistorySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ToAccountId",
                table: "TransactionHistory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ToAccountId",
                value: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ToAccountId",
                value: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ToAccountId",
                value: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ToAccountId",
                table: "TransactionHistory",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Account_ToAccountId",
                table: "TransactionHistory",
                column: "ToAccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Account_ToAccountId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_ToAccountId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "ToAccountId",
                table: "TransactionHistory");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "LicenseTypeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "LicenseTypeId",
                value: null);
        }
    }
}
