using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Asset");

            migrationBuilder.InsertData(
                table: "ChatBox",
                columns: new[] { "Id", "AccountId_1", "AccountId_2" },
                values: new object[,]
                {
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2") },
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1295c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1") },
                    { new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1296c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2") }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "LastModificatedOn", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[,]
                {
                    { new Guid("2c8542d4-41bd-492b-9d21-905c6a8b0532"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "4 - 6 tuần", "Mô tả Dịch vụ phát triển website", null, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Dịch vụ phát triển website", 150000.0, "https://laptopdieplinh.com/uploads/7%20c%C3%B4ng%20c%E1%BB%A5%20ph%C3%A1t%20tri%E1%BB%83n%20website%20b%E1%BA%A1n%20c%E1%BA%A7n%20bi%E1%BA%BFt%20-%200.jpg" },
                    { new Guid("3c8542d4-41bd-492b-9d21-905c6a8b0532"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tuần", "Mô tả Dịch vụ in ấn", null, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Dịch vụ in ấn", 50000.0, "https://channel.mediacdn.vn/2022/3/17/photo-1-1647512803989607433836.jpg" },
                    { new Guid("4c8542d4-41bd-492b-9d21-905c6a8b0532"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "3 - 4 tuần", "Mô tả Dịch vụ quản lý dự án", null, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Dịch vụ quản lý dự án", 120000.0, "https://www.inandaiduong.com/wp-content/uploads/2015/01/dich-vu-thiet-ke-in-an.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "ChatBoxId", "CreatedBy", "CreatedOn", "Message", "RequestStatus", "ServiceId", "Timeline" },
                values: new object[] { new Guid("7d580000-c214-88a4-2ef8-08dc1ef3c2fb"), new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "yeu cau lam website ecommerce", 0, new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"), "2 - 3 tuần" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1295c"));

            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1296c"));

            migrationBuilder.DeleteData(
                table: "Request",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-2ef8-08dc1ef3c2fb"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2c8542d4-41bd-492b-9d21-905c6a8b0532"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("3c8542d4-41bd-492b-9d21-905c6a8b0532"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("4c8542d4-41bd-492b-9d21-905c6a8b0532"));

            migrationBuilder.DeleteData(
                table: "ChatBox",
                keyColumn: "Id",
                keyValue: new Guid("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("8225058f-9f38-49f2-a68d-d9237b0a550f"),
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"),
                column: "Order",
                value: 0);
        }
    }
}
