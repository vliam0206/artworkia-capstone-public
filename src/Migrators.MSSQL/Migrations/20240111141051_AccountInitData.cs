using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AccountInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Artwork",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Avatar", "Bio", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "Fullname", "LastModificatedBy", "LastModificatedOn", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("74340000-dfe2-e4a8-680f-08dc12af1e4b"), "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 660, DateTimeKind.Local).AddTicks(2891), null, null, "admin@example.com", "Quản trị viên hệ thống", null, new DateTime(2024, 1, 11, 21, 10, 51, 660, DateTimeKind.Local).AddTicks(2891), "orb6aaxBx7oJVjOQQ57zmuLSNck9ctot5YACWUnxI8ugB4X+", 0, "admin" },
                    { new Guid("74340000-dfe2-e4a8-7363-08dc12af1e4a"), "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 654, DateTimeKind.Local).AddTicks(245), null, null, "phu@example.com", "Huỳnh Vạn Phú", null, new DateTime(2024, 1, 11, 21, 10, 51, 654, DateTimeKind.Local).AddTicks(246), "954pvwXuIH4HcjjiTe5lM2B8v3Pzphhnwzmfjkc0p9LRUuKb", 2, "phuhuynh" },
                    { new Guid("74340000-dfe2-e4a8-7881-08dc12af1e49"), "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 647, DateTimeKind.Local).AddTicks(6029), null, null, "hoanganh@example.com", "Đặng Hoàng Anh", null, new DateTime(2024, 1, 11, 21, 10, 51, 647, DateTimeKind.Local).AddTicks(6030), "htz5x2TQBgjGcp3dlOh0LRujGnF4zV1G4PmjE2mvu3XZ6SJx", 2, "hoanganh" },
                    { new Guid("74340000-dfe2-e4a8-7ca3-08dc12af1e48"), "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 641, DateTimeKind.Local).AddTicks(1508), null, null, "user@example.com", "Người dùng mặc định", null, new DateTime(2024, 1, 11, 21, 10, 51, 641, DateTimeKind.Local).AddTicks(1524), "7HTJvRfqNwaO6yHVfFveGOoquV80AWZ+UZlaSXNQfwM7KCh3", 2, "user" },
                    { new Guid("74340000-dfe2-e4a8-f9c1-08dc12af1e49"), "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 650, DateTimeKind.Local).AddTicks(9061), null, null, "thong@example.com", "Nguyễn Trung Thông", null, new DateTime(2024, 1, 11, 21, 10, 51, 650, DateTimeKind.Local).AddTicks(9076), "JJpmI/CO2zPPtXD0MTt+CYOIsDOcCjpPSaqAKv/rvgMjsRnS", 2, "thong" },
                    { new Guid("74340000-dfe2-e4a8-fa75-08dc12af1e48"), "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 644, DateTimeKind.Local).AddTicks(3760), null, null, "lamlam@example.com", "Trúc Lam Võ", null, new DateTime(2024, 1, 11, 21, 10, 51, 644, DateTimeKind.Local).AddTicks(3761), "iiF65XcB0iuT5Swo7YnCvSVgPhsQHs7lJV0tGSnEKqCgOeFc", 2, "lamlam" },
                    { new Guid("74340100-dfe2-e4a8-edd8-08dc12af1e4a"), "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg", null, null, new DateTime(2024, 1, 11, 21, 10, 51, 657, DateTimeKind.Local).AddTicks(1604), null, null, "mod@example.com", "Kiểm soát viên", null, new DateTime(2024, 1, 11, 21, 10, 51, 657, DateTimeKind.Local).AddTicks(1605), "YUltgswQdt5wTptooTXDlA+xto0p6pwRjSfQ88ew7WL7lBgq", 1, "mod" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-680f-08dc12af1e4b"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-7363-08dc12af1e4a"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-7881-08dc12af1e49"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-7ca3-08dc12af1e48"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-f9c1-08dc12af1e49"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340000-dfe2-e4a8-fa75-08dc12af1e48"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("74340100-dfe2-e4a8-edd8-08dc12af1e4a"));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Artwork",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
