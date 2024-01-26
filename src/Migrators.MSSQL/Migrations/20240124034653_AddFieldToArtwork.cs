using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldToArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Artwork",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Artwork",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Artwork",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("35966d1a-9b08-4743-b1c3-474a58350f5e"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 2, 2, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("56f86f82-4622-4710-8d1c-b8c1664711a2"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("8c24a1d8-9f14-44cd-9e86-2c542d14413c"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("91f9a14d-66a9-43da-8e43-2579baf7c8a7"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("9202bb7f-71f3-4641-b1d4-9bc858416d84"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"),
                columns: new[] { "CommentCount", "LikeCount", "ViewCount" },
                values: new object[] { 0, 0, 99 });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Artwork");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 17, 21, 20, 0, 399, DateTimeKind.Local).AddTicks(4818));
        }
    }
}
