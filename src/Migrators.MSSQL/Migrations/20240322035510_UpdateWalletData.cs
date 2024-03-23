using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWalletData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Balance",
                value: 200000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Balance",
                value: 100000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Balance",
                value: 100000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Balance",
                value: 100000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Balance",
                value: 100000.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Balance",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Balance",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Balance",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Balance",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Balance",
                value: 1000.0);
        }
    }
}
