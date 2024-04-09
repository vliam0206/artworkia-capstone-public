using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldProposalAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "ProposalAsset",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "ProposalAsset",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Milestone",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "MilestoneName", "ProposalId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thỏa thuận đã được tạo", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặt cọc thành công 20000 xu (25%)", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thỏa thuận đã được chấp nhận", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gửi tài nguyên thỏa thuận (phác thảo)", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gửi tài nguyên thỏa thuận (phác thảo)", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gửi tài nguyên thỏa thuận (cuối cùng)", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gửi tài nguyên thỏa thuận (chỉnh sửa)", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàn tất thanh toán 60000 xu (75%)", new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedBy", "Description", "ProjectTitle", "Total" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "Yêu cầu làm website mua bán thiệp đám cưới:\r\n                    - Giao diện trực quan, dễ sử dụng.\r\n                    - Tìm kiếm và bộ lọc sản phẩm.\r\n                    - Hệ thống thanh toán an toàn.", "Yêu cầu làm website mua bán thiệp đám cưới.", 80000.0 });

            migrationBuilder.InsertData(
                table: "ProposalAsset",
                columns: new[] { "Id", "ContentType", "CreatedBy", "CreatedOn", "Location", "ProposalAssetName", "ProposalId", "Size", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "zip", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", "concept1_3435438593.zip", new Guid("00000000-0000-0000-0000-000000000001"), 13094430m, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "zip", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", "concept1_3435433593.zip", new Guid("00000000-0000-0000-0000-000000000001"), 12094430m, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "zip", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", "concept1_3435733593.zip", new Guid("00000000-0000-0000-0000-000000000001"), 16094430m, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "zip", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", "concept1_3433433593.zip", new Guid("00000000-0000-0000-0000-000000000001"), 16084430m, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "Message", "RequestStatus" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu làm website mua bán.", 2 });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "Budget", "ChatBoxId", "CreatedBy", "CreatedOn", "Message", "RequestStatus", "ServiceId", "Timeline" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), 69000.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu làm website mua bán thiệp đám cưới.", 1, new Guid("00000000-0000-0000-0000-000000000001"), "2 - 3 tuần" });

            migrationBuilder.InsertData(
                table: "TransactionHistory",
                columns: new[] { "Id", "AssetId", "CreatedBy", "CreatedOn", "Detail", "Price", "ProposalId", "ToAccountId", "TransactionStatus" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), null, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 3, 9, 59, 59, 0, DateTimeKind.Local), "	Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)", 20000.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), null, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 2, 1, 9, 59, 59, 0, DateTimeKind.Local), "	Đặt cọc thỏa thuận \"Làm web thiệp cưới\" (25%)", 20000.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Milestone",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "ProposalAsset",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ProposalAsset",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ProposalAsset",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "ProposalAsset",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "ProposalAsset");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProposalAsset");

            migrationBuilder.UpdateData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedBy", "Description", "ProjectTitle", "Total" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), "yeu cau lam website ecommerce", "yeu cau lam website ecommerce", 69000.0 });

            migrationBuilder.UpdateData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "Message", "RequestStatus" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "yeu cau lam website ecommerce", 0 });
        }
    }
}
