using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LicenseTypeId",
                table: "Artwork",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LicenseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    LicenseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareUsed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SoftwareName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareUsed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareDetail",
                columns: table => new
                {
                    SoftwareUsedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDetail", x => new { x.SoftwareUsedId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_SoftwareDetail_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDetail_SoftwareUsed_SoftwareUsedId",
                        column: x => x.SoftwareUsedId,
                        principalTable: "SoftwareUsed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "LicenseTypeId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "LicenseType",
                columns: new[] { "Id", "LicenseDescription", "LicenseName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Tất cả các quyền đều được bảo lưu. Không ai được sao chép, phân phối hoặc sử dụng tác phẩm mà không có sự cho phép của tác giả", "All Rights Reserved" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, cũng như tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu, miễn là họ ghi công tác phẩm của bạn một cách đúng cách", "Attribution (CC BY)" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, cũng như tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu, miễn là họ ghi công tác phẩm của bạn một cách đúng cách. Tất cả các tác phẩm phái sinh phải được phân phối dưới cùng một giấy phép như tác phẩm ban đầu", "Attribution ShareAlike (CC BY-SA)" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, miễn là họ ghi công tác phẩm của bạn một cách đúng cách. Tác phẩm không được thay đổi hoặc tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu", "Attribution NoDerivs (CC BY-ND)" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, cũng như tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu, miễn là họ ghi công tác phẩm của bạn một cách đúng cách. Tuy nhiên, họ không được sử dụng tác phẩm với mục đích thương mại", "Attribution-NonCommercial (CC BY-NC)" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, cũng như tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu, miễn là họ ghi công tác phẩm của bạn một cách đúng cách. Tuy nhiên, họ không được sử dụng tác phẩm với mục đích thương mại. Tất cả các tác phẩm phái sinh phải được phân phối dưới cùng một giấy phép như tác phẩm ban đầu", "Attribution-NonCommercial-ShareAlike (CC BY-NC-SA)" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Cho phép người dùng chia sẻ, sao chép, phân phối và trình bày tác phẩm, miễn là họ ghi công tác phẩm của bạn một cách đúng cách. Tuy nhiên, họ không được sử dụng tác phẩm với mục đích thương mại. Tác phẩm không được thay đổi hoặc tạo ra các tác phẩm phái sinh từ tác phẩm ban đầu", "Attribution-NonCommercial-NoDerivs (CC BY-NC-ND)" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Tác phẩm được công bố dưới dạng CC0 cho phép người khác có toàn quyền phân phối, sao chép, chỉnh sửa và xây dựng trên nội dung gốc mà không gặp bất kỳ ràng buộc nào. Bao gồm cả việc sử dụng cho mục đích thương mại.", "No Rights Reserved" }
                });

            migrationBuilder.InsertData(
                table: "SoftwareUsed",
                columns: new[] { "Id", "SoftwareName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Adobe Photoshop" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Adobe Illustrator" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Adobe After Effect" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Adobe Premiere" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Adobe Lightroom" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Adobe XD" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Figma" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sketch" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "CorelDRAW" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "Inkscape" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "Blender" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "Cinema 4D" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "Maya" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "ZBrush" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "Substance Painter" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Substance Designer" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Substance Alchemist" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Marvelous Designer" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "KeyShot" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Lumion" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "AutoCAD" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Revit" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "3ds Max" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "Rhino" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "Grasshopper" },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), "Vectorworks" },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), "ArchiCAD" },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), "SketchUp" },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), "Photoshop Lightroom" },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), "Photoshop Elements" },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), "PaintShop Pro" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "GIMP" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "Affinity Photo" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "Affinity Designer" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "Affinity Publisher" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "Clip Studio Paint" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Krita" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "MediBang Paint" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "Procreate" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "ArtRage" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "Rebelle" },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), "TwistedBrush Pro Studio" },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), "Canva" },
                    { new Guid("00000000-0000-0000-0000-00000000002c"), "Paint Tool SAI" },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), "Artweaver" },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), "MyPaint" },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), "FireAlpaca" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "OpenCanvas" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "Paint.NET" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "Pixia" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "SmoothDraw" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "Tayasui Sketches" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "Unity" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "Unreal Engine" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "GameMaker Studio" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "Godot Engine" }
                });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_LicenseTypeId",
                table: "Artwork",
                column: "LicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDetail_ArtworkId",
                table: "SoftwareDetail",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareUsed_SoftwareName",
                table: "SoftwareUsed",
                column: "SoftwareName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artwork_LicenseType_LicenseTypeId",
                table: "Artwork",
                column: "LicenseTypeId",
                principalTable: "LicenseType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artwork_LicenseType_LicenseTypeId",
                table: "Artwork");

            migrationBuilder.DropTable(
                name: "LicenseType");

            migrationBuilder.DropTable(
                name: "SoftwareDetail");

            migrationBuilder.DropTable(
                name: "SoftwareUsed");

            migrationBuilder.DropIndex(
                name: "IX_Artwork_LicenseTypeId",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "LicenseTypeId",
                table: "Artwork");
        }
    }
}
