using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldToImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ImageHash",
                table: "Image",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("01aa2232-7628-4227-b034-1c1a32cad359"),
                column: "ImageHash",
                value: null);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("36208d9b-471a-4a88-be28-adabfd1f2ae5"),
                column: "ImageHash",
                value: null);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5d96552b-ff92-4064-8858-5e1e96ee9899"),
                column: "ImageHash",
                value: null);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ae8fb7be-5c63-481e-b997-2ada5ac5392b"),
                column: "ImageHash",
                value: null);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ff16271c-c04a-4cec-b6f1-04b555659b5a"),
                column: "ImageHash",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHash",
                table: "Image");
        }
    }
}
