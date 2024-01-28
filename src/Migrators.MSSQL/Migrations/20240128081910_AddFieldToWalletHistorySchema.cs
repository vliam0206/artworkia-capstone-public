using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldToWalletHistorySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletHistory_Wallet_WalletId",
                table: "WalletHistory");

            migrationBuilder.DropIndex(
                name: "IX_WalletHistory_WalletId",
                table: "WalletHistory");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "WalletHistory");

            migrationBuilder.AddColumn<string>(
                name: "AppTransId",
                table: "WalletHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0290"),
                column: "AppTransId",
                value: "240128_7635981");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0291"),
                column: "AppTransId",
                value: "180623_2054176");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0292"),
                column: "AppTransId",
                value: "210430_6849203");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0293"),
                column: "AppTransId",
                value: "190815_3095728");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0294"),
                column: "AppTransId",
                value: "220506_1478963");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0295"),
                column: "AppTransId",
                value: "231112_8023456");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0296"),
                column: "AppTransId",
                value: "200925_6193840");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0297"),
                column: "AppTransId",
                value: "171212_4357692");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0298"),
                column: "AppTransId",
                value: "160509_9270134");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0299"),
                column: "AppTransId",
                value: "250321_4685027");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029a"),
                column: "AppTransId",
                value: "231205_7890123");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029b"),
                column: "AppTransId",
                value: "200703_4567890");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029c"),
                column: "AppTransId",
                value: "180924_1234567");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029d"),
                column: "AppTransId",
                value: "210817_8901234");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029e"),
                column: "AppTransId",
                value: "220129_5678901");

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029f"),
                column: "AppTransId",
                value: "160827_3456789");

            migrationBuilder.CreateIndex(
                name: "IX_WalletHistory_CreatedBy",
                table: "WalletHistory",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletHistory_Account_CreatedBy",
                table: "WalletHistory",
                column: "CreatedBy",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletHistory_Account_CreatedBy",
                table: "WalletHistory");

            migrationBuilder.DropIndex(
                name: "IX_WalletHistory_CreatedBy",
                table: "WalletHistory");

            migrationBuilder.DropColumn(
                name: "AppTransId",
                table: "WalletHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "WalletHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0290"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0291"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0292"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0293"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0294"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0295"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0296"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0297"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0298"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0299"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029a"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029b"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029c"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029d"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029e"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0"));

            migrationBuilder.UpdateData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029f"),
                column: "WalletId",
                value: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0"));

            migrationBuilder.CreateIndex(
                name: "IX_WalletHistory_WalletId",
                table: "WalletHistory",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletHistory_Wallet_WalletId",
                table: "WalletHistory",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
