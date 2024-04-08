using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddDataV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Bio",
                value: "Tôi là một thiết kế UI/UX đam mê và sáng tạo, đã tham gia vào nhiều dự án thành công trong lĩnh vực công nghệ.");

            migrationBuilder.InsertData(
                table: "Proposal",
                columns: new[] { "Id", "Category", "ChatBoxId", "CreatedBy", "CreatedOn", "Description", "InitialPrice", "NumberOfConcept", "NumberOfRevision", "OrdererId", "ProjectTitle", "ProposalStatus", "ServiceId", "TargetDelivery", "Total" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Website", new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "yeu cau lam website ecommerce", 20000.0, 2, 3, new Guid("00000000-0000-0000-0000-000000000005"), "yeu cau lam website ecommerce", 4, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 69000.0 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Detail", "ProposalId", "Vote" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "good", new Guid("00000000-0000-0000-0000-000000000001"), 5.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Bio",
                value: "Tôi là là một thiết kế UI/UX đam mê và sáng tạo, đã tham gia vào nhiều dự án thành công trong lĩnh vực công nghệ.");
        }
    }
}
