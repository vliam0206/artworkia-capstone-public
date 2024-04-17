using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                columns: new[] { "Avatar", "Username" },
                values: new object[] { "https://yt3.googleusercontent.com/ytc/AIdro_klHVaP6_ZcnT8VyPFedRHgJOPOym_tLSxoFCL0KJSZL1k=s900-c-k-c0x00ffffff-no-rj", "melodysheep" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Avatar", "Bio" },
                values: new object[] { "https://i.pinimg.com/736x/58/29/bd/5829bdfa438410a86cf9b180c077939c.jpg", "Sinh viên đại học mỹ thuật HCM, thích vẽ tranh phong cách Nhật Bản, nếu thích hãy theo dõi mình nhé." });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "Avatar",
                value: "https://i.pinimg.com/originals/30/33/0b/30330b5e8e0f772f0edaa310294703a2.jpg");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "Bio",
                value: "Tôi là một họa sĩ người Áo có ước mơ vào trường Mỹ Thuật");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ViewCount",
                value: 1344);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ViewCount",
                value: 2138);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Thumbnail",
                value: "https://bizweb.dktcdn.net/100/378/894/files/5.jpg?v=1627978886825");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Thumbnail",
                value: "https://static-company.waka.vn/img.media/tin%20t%E1%BB%A9c/38540.jpg");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedBy", "IsAIGenerated" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), true });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Anh như con cáo Em như cành nho xanh Khi em còn trẻ và đẹp em lại ko dành cho anhhhhh.", "Cáo già" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "ViewCount",
                value: 1234);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "ViewCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "ThumbnailName",
                value: "00000000-0000-0000-0000-000000000012_t.jpg");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedBy", "LicenseTypeId", "ThumbnailName", "ViewCount" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000013_t.jpg", 3045 });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CommentCount", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsAIGenerated", "LastModificatedBy", "LicenseTypeId", "LikeCount", "Note", "Privacy", "State", "Thumbnail", "ThumbnailName", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000d"), 0, new Guid("00000000-0000-0000-0000-000000000015"), new DateTime(2023, 11, 11, 9, 37, 42, 345, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/originals/7f/b2/ab/7fb2abc0dddd2aa40a86ce6c318b369a.jpg", "00000000-0000-0000-0000-00000000000d_t.jpg", "Làng quê", 234 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 0, new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2023, 11, 14, 0, 11, 3, 678, DateTimeKind.Local), null, null, "A collection of 173 wallpapers in 4K resolution from THE SIGHTS OF SPACE", false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://f4.bcbits.com/img/a0127149981_16.jpg", "00000000-0000-0000-0000-000000000014_t.jpg", "Không gian vũ trụ", 725 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 0, new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2023, 11, 14, 21, 11, 3, 678, DateTimeKind.Local), null, null, "Save the date.  THE HUMAN FUTURE drops on August 15.  Casting my stone in the opposite direction of all the pessimists out there.  see you soon :)", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://yt3.ggpht.com/7CFh0HeCsVSD9UfK1LSc9imflCpKDZT41gNjj_qehvRKt0J9fgmjw2tYjf4oMpbsn0BagczFhx_TTQ=s1600-rw-nd-v1", "00000000-0000-0000-0000-000000000015_t.jpg", "Tương lai loài người", 435 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), 0, new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2023, 11, 20, 15, 20, 45, 890, DateTimeKind.Local), null, null, "How might we discover intelligent life?\r\n\r\nInstead of waiting for radio signals or scanning alien atmospheres, we could look to distant asteroid fields for evidence.  Advanced civilizations would have numerous reasons to probe asteroids for materials. They are rich in resources and easier to manipulate because of their lower gravity.\r\n\r\nSpotting chemical anomalies or infrared waste heat around distant asteroid fields could lead us to the ultimate discovery.\r\n\r\nPresenting THE OUTPOST: a digital art piece from Life Beyond 3", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://yt3.ggpht.com/gD2jfNal37ZYf6zkA7CX8CdBQ3WJDP9wFxA-JgrTl0RMGmWh7QcaWG1L2dzBWHUV_qd20ddxXJSMi90=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1", "00000000-0000-0000-0000-000000000016_t.jpg", "THE OUTPOST", 564 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), 0, new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2023, 11, 21, 15, 30, 3, 678, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F106127234_p0.jpg?alt=media&token=86c5c12c-bee7-4a57-8db1-402e317d5c23", "00000000-0000-0000-0000-000000000017_t.jpg", "Mọt sách", 725 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), 0, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 22, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Bức tranh hấp dẫn này thường được so sánh với \"Mona Lisa\". Bên cạnh sự khác biệt về phong cách, về mặt kỹ thuật \"Girl With a Pearl Earring\" thậm chí không phải là một bức chân dung, mà là một \"tronie\" - một từ tiếng Hà Lan để chỉ bức tranh của một nhân vật tưởng tượng với các đặc điểm phóng đại.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.kiettacnghethuat.com/wp-content/uploads/Girl-With-a-Pearl-Earring.jpg", "00000000-0000-0000-0000-000000000018_t.jpg", "Cô Gái Đeo Bông Tai Ngọc Trai", 124 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), 0, new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 11, 23, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Bức tranh \"The Starry Night\" của Vincent van Gogh là một trong những bức tranh nổi tiếng nhất của ông. Bức tranh này được vẽ vào năm 1889 và hiện đang được trưng bày tại Bảo tàng Nghệ thuật Modern ở New York.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.kiettacnghethuat.com/wp-content/uploads/The-Starry-Night.jpg", "00000000-0000-0000-0000-000000000019_t.jpg", "Đêm đầy sao", 462 },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), 0, new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 11, 24, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Thiếu nữ bên hoa huệ là một tác phẩm tranh sơn dầu do họa sĩ Tô Ngọc Vân sáng tác năm 1943. Bức tranh mô tả chân dung một thiếu nữ mặc áo dài trắng bên cạnh lọ hoa huệ trắng.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg/800px-To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg", "00000000-0000-0000-0000-00000000001a_t.jpg", "Thiếu nữ bên hoa huệ", 874 },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 11, 25, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/originals/5b/43/fc/5b43fc89abad25aa3359bfe0f27923f9.jpg", "00000000-0000-0000-0000-00000000001b_t.jpg", "꒰𝙰𝚒 𝙰𝚛𝚝꒱ Wallpaper", 124 },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), 0, new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2023, 11, 26, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://upload.wikimedia.org/wikipedia/commons/e/e5/Adolf_Hitler_-_Wien_Oper.jpg", "00000000-0000-0000-0000-00000000001c_t.jpg", "Nhà hát Opera Vienna", 666 },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), 0, new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2023, 11, 27, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://upload.wikimedia.org/wikipedia/commons/9/93/Adolf_Hitler_-_Hofbr%C3%A4uhaus.jpg", "00000000-0000-0000-0000-00000000001d_t.jpg", "Hofbräuhaus, Munich", 144 },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), 0, new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2023, 11, 28, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg/1024px-Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg", "00000000-0000-0000-0000-00000000001e_t.jpg", "Lâu đài Old Town ở Munich", 452 },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), 0, new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2023, 11, 29, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Adolf_Hitler_Der_Alte_Hof.jpg/1024px-Adolf_Hitler_Der_Alte_Hof.jpg", "00000000-0000-0000-0000-00000000001f_t.jpg", "Khoảng sân trong ở phủ thống sứ cũ tại Munich", 124 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), 0, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 11, 29, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Hầu hết các bức ảnh đều chụp cách đây mấy chục năm, nước ảnh ố mờ, bay màu. Có nhiều bức ảnh được vẽ lại theo trí nhớ người thân nên để phục chế lại phải mất nhiều thời gian, phải cẩn thận chỉnh sửa từng chi tiết", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png", "00000000-0000-0000-0000-000000000020_t.jpg", "Phục chế ảnh liệt sĩ", 968 }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000e") }
                });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001_i0.jpg", "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000002_i0.jpg", "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000003_i0.jpg", "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000004_i0.jpg", "https://bizweb.dktcdn.net/100/378/894/files/5.jpg?v=1627978886825" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000004_i1.jpg", "https://bizweb.dktcdn.net/100/378/894/files/4.jpg?v=1627978828806", 1 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), "00000000-0000-0000-0000-000000000006_i0.jpg", "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), "00000000-0000-0000-0000-000000000007_i0.jpg", "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), "00000000-0000-0000-0000-000000000008_i0.jpg", "https://static-company.waka.vn/img.media/tin%20t%E1%BB%A9c/38540.jpg" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), "00000000-0000-0000-0000-00000000000b_i0.jpg", "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), "00000000-0000-0000-0000-00000000000d_i0.jpg", "https://i.pinimg.com/originals/7f/b2/ab/7fb2abc0dddd2aa40a86ce6c318b369a.jpg" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), "00000000-0000-0000-0000-00000000000e_i1.jpg", "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), "00000000-0000-0000-0000-00000000000e_i2.jpg", "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), "00000000-0000-0000-0000-00000000000f_i0.jpg", "https://i.pinimg.com/originals/db/93/a1/db93a131d59201ed997d606ea33c4933.jpg" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), "00000000-0000-0000-0000-00000000000f_i1.jpg", "https://i.pinimg.com/originals/b5/d4/7e/b5d47e1cf4555983a8017e59409b4d4a.jpg" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), "00000000-0000-0000-0000-000000000010_i0.jpg", "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), "00000000-0000-0000-0000-000000000011_i0.jpg", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i0.jpg?alt=media&token=e9a93f6f-4bcf-4517-824a-dacd402bdcec", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002a"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), "00000000-0000-0000-0000-000000000011_i1.jpg", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i1.jpg?alt=media&token=3442240e-37f5-42f9-be58-5c359ebcde5c", 1 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000005"), null, "00000000-0000-0000-0000-000000000005_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000009"), null, "00000000-0000-0000-0000-000000000009_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-00000000000a"), null, "00000000-0000-0000-0000-00000000000a_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000000e"), null, "00000000-0000-0000-0000-00000000000e_i0.jpg", null, null, "https://i.pinimg.com/originals/b5/7e/14/b57e14aa401d41db2072d1b0ccfbde2b.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000011"), null, "00000000-0000-0000-0000-000000000011_i2.jpg", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i2.jpg?alt=media&token=4d6ad124-294d-4059-b21d-a37cfb3d0c6a", 2 },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i0.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i1.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F2.png?alt=media&token=10e991c2-11ac-469b-9933-3b223fe17f5b", 1 },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i2.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F3.png?alt=media&token=13f47f61-2372-4b87-b8f4-806c5ef956ee", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i3.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F4.png?alt=media&token=53a9b98e-1875-48d6-a880-6b935081afe5", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i4.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F5.png?alt=media&token=4d9137a2-5836-4cee-8e36-c1b87f9236c6", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i4.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F6.png?alt=media&token=3b05c46f-6ed0-42d6-aa84-1ef96a880f99", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000013"), null, "00000000-0000-0000-0000-000000000013_i0.png", null, null, "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Text",
                value: "Chào bạn");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Text",
                value: "Mình muốn bạn làm website mua bán");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Text",
                value: "Nếu được hãy chấp nhận nhé");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Text",
                value: "Yêu cầu khác đi");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Text",
                value: "Vầy được chưa?");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Text",
                value: "OK, mình muốn 100k, giá vậy được ko?");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "Text",
                value: "80k được ko?");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Text",
                value: "Thôi cũng được, bạn muốn khi nào xong?");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Text",
                value: "Cuối tháng 1");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "Text",
                value: "Để mình tạo thỏa thuận");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Text",
                value: "ok mình làm đây");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DeliveryTime", "Description", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[] { "1 - 2 tháng", "Dịch vụ thiết kế nhân vật trò chơi 2D, từ indie tới AAA", 2, 2, "Dịch vụ thiết kế nhân vật trò chơi 2D", 100000.0, "https://static.vecteezy.com/system/resources/previews/023/289/956/original/cute-monster-doodle-character-design-flat-illustration-suitable-for-poster-banner-mascot-or-event-related-template-free-vector.jpg" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DeliveryTime", "Description", "ServiceName", "Thumbnail" },
                values: new object[] { "3 - 4 tháng", "Dịch vụ thiết kế nhân vật trò chơi 3D, từ indie tới AAA", "Dịch vụ thiết kế nhân vật trò chơi 3D", "https://masterbundles.com/wp-content/uploads/2023/11/media-2-816.jpg" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "LastModificatedOn", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tuần", "Tôi không muốn làm việc phục dựng, phục chế ảnh như một động tác khô khan về kỹ thuật, tôi còn muốn kể lại những câu chuyện thực tế về liệt sĩ bằng ngôn ngữ hội họa và nhiếp ảnh", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Phục chế chân dung liệt sĩ", 20000.0, "https://media-cdn-v2.laodong.vn/storage/newsportal/2023/7/26/1221583/CAF7870B-5832-44DC-B.jpeg" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tháng", "Thiết kế hình ảnh khoa học viễn tưởng phong phú và độc đáo, tùy chỉnh cho không gian của bạn. Từ các bức tranh tường tường đồ sộ đến các tác phẩm nghệ thuật nhỏ hơn, chúng tôi mang đến sự sáng tạo và phong cách cho mọi dự án.", null, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "Thiết kế hình ảnh khoa học viễn tưởng", 50000.0, "https://cdn.musicbed.com/image/upload/c_fill,dpr_auto,f_auto,g_auto,q_40,w_1200,h_630/v1658956186/production/albums/9887" }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000008") }
                });

            migrationBuilder.InsertData(
                table: "SoftwareUsed",
                columns: new[] { "Id", "SoftwareName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000039"), "Stable Diffusion" },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), "Midjourney" }
                });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "TagName",
                value: "Xã hội");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "TagName",
                value: "Tối giản");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "TagName",
                value: "Động vật");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "TagName",
                value: "Sơn dầu");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "TagName",
                value: "Khoa học");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "TagName",
                value: "Kiến trúc");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000019"), "AI" },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), "Lịch sử" },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), "Chính trị" },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), "Việt Nam" },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), "Nhiếp ảnh" },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), "Ảnh bìa" },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), "Tâm lý" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "Vũ trụ" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "Tương lai" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "Nhân vật" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "Trò chơi" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "Khoa học viễn tưởng" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Kinh điển" }
                });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000018") }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000014"), null, "00000000-0000-0000-0000-000000000014_i0.png", null, null, "https://public-files.gumroad.com/ydorwqbnmsl1yueuyhnr90ceo7sq", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000014"), null, "00000000-0000-0000-0000-000000000014_i1.png", null, null, "https://public-files.gumroad.com/1tmubanfhbhfs7fi4mwbw1s5nyc0", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000014"), null, "00000000-0000-0000-0000-000000000014_i2.png", null, null, "https://public-files.gumroad.com/7ml9boypxaoisvvaio5eajau57ts", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000014"), null, "00000000-0000-0000-0000-000000000014_i3.png", null, null, "https://public-files.gumroad.com/t1tx8r7s2jhhedtr2zqyc3r9edc6", 3 },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-000000000015"), null, "00000000-0000-0000-0000-000000000015_i0.png", null, null, "https://yt3.ggpht.com/7CFh0HeCsVSD9UfK1LSc9imflCpKDZT41gNjj_qehvRKt0J9fgmjw2tYjf4oMpbsn0BagczFhx_TTQ=s1600-rw-nd-v1", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000016"), null, "00000000-0000-0000-0000-000000000016_i0.png", null, null, "https://yt3.ggpht.com/gD2jfNal37ZYf6zkA7CX8CdBQ3WJDP9wFxA-JgrTl0RMGmWh7QcaWG1L2dzBWHUV_qd20ddxXJSMi90=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000016"), null, "00000000-0000-0000-0000-000000000016_i1.png", null, null, "https://yt3.ggpht.com/soXomuCz4k_xBxpb_p6K7nAht6BlCfzh8p3PfTPU2dt3iGX25Ga-W-Noiow1GPr5ii9seYFsCci-=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1", 1 },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000016"), null, "00000000-0000-0000-0000-000000000016_i2.png", null, null, "https://yt3.ggpht.com/An5n_i_kbv45-ijvkogN9T98slicRZYEsxmyallrHtsILGoNgwdOs0_93C94duiwdClNGWFtoG-f=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1", 2 },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000016"), null, "00000000-0000-0000-0000-000000000016_i3.png", null, null, "https://yt3.ggpht.com/togZdny_IHrLbAa73ZmBXhUlt-Br4Rdrjpq2iySYPgt7S3bATckHvipkjv6gsDmjkJtXnM8DazDgPg=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000017"), null, "00000000-0000-0000-0000-000000000017_i0.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F106127234_p0.jpg?alt=media&token=86c5c12c-bee7-4a57-8db1-402e317d5c23", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000018"), null, "00000000-0000-0000-0000-000000000018_i0.png", null, null, "https://www.kiettacnghethuat.com/wp-content/uploads/Girl-With-a-Pearl-Earring.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000019"), null, "00000000-0000-0000-0000-000000000019_i0.jpg", null, null, "https://www.kiettacnghethuat.com/wp-content/uploads/The-Starry-Night.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000048"), new Guid("00000000-0000-0000-0000-00000000001a"), null, "00000000-0000-0000-0000-00000000001a_i0.jpg", null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg/800px-To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000004a"), new Guid("00000000-0000-0000-0000-00000000001b"), null, "00000000-0000-0000-0000-00000000001b_i0.jpg", null, null, "https://i.pinimg.com/originals/5b/43/fc/5b43fc89abad25aa3359bfe0f27923f9.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000004d"), new Guid("00000000-0000-0000-0000-00000000001c"), null, "00000000-0000-0000-0000-00000000001c_i0.jpg", null, null, "https://upload.wikimedia.org/wikipedia/commons/e/e5/Adolf_Hitler_-_Wien_Oper.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000004e"), new Guid("00000000-0000-0000-0000-00000000001d"), null, "00000000-0000-0000-0000-00000000001d_i0.jpg", null, null, "https://upload.wikimedia.org/wikipedia/commons/9/93/Adolf_Hitler_-_Hofbr%C3%A4uhaus.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000004f"), new Guid("00000000-0000-0000-0000-00000000001e"), null, "00000000-0000-0000-0000-00000000001e_i0.jpg", null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg/1024px-Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-00000000001f"), null, "00000000-0000-0000-0000-00000000001f_i0.jpg", null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Adolf_Hitler_Der_Alte_Hof.jpg/1024px-Adolf_Hitler_Der_Alte_Hof.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000051"), new Guid("00000000-0000-0000-0000-000000000020"), null, "00000000-0000-0000-0000-000000000020_i0.png", null, null, "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000052"), new Guid("00000000-0000-0000-0000-000000000020"), null, "00000000-0000-0000-0000-000000000020_i1.png", null, null, "https://i.upanh.org/2024/04/17/image689a466ed577378c.png", 1 }
                });

            migrationBuilder.InsertData(
                table: "Proposal",
                columns: new[] { "Id", "ActualDelivery", "Category", "CreatedBy", "CreatedOn", "Description", "InitialPrice", "NumberOfConcept", "NumberOfRevision", "OrdererId", "ProjectTitle", "ProposalStatus", "ServiceId", "TargetDelivery", "Total" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu thiết kế một bức tranh tường với chủ đề khoa học viễn tưởng cho không gian phòng khách.", 0.25, 2, 3, new Guid("00000000-0000-0000-0000-00000000000a"), "Thiết kế Hình Ảnh Khoa Học - Dự Án Tranh Tường.", 4, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000.0 },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), " Yêu cầu thiết kế các tác phẩm nghệ thuật nhỏ về khoa học viễn tưởng để trang trí không gian phòng làm việc.", 0.25, 2, 3, new Guid("00000000-0000-0000-0000-00000000000c"), "Thiết kế Hình Ảnh Khoa Học - Dự Án Trang Trí Phòng Làm Việc", 4, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000.0 },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu thiết kế một loạt các poster khoa học viễn tưởng để trưng bày trong sự kiện khoa học của trường địa phương.", 0.25, 2, 3, new Guid("00000000-0000-0000-0000-00000000000d"), "Thiết kế Hình Ảnh Khoa Học - Dự Án Poster Khoa Học", 4, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80000.0 },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu thiết kế bìa và các hình minh họa cho cuốn sách truyện khoa học viễn tưởng mới.", 0.25, 2, 3, new Guid("00000000-0000-0000-0000-00000000000e"), "Thiết kế Hình Ảnh Khoa Học - Dự Án Sách Truyện Khoa Học", 4, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000.0 },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yêu cầu thiết kế các cảnh và hiệu ứng đặc biệt cho một bộ phim ngắn với chủ đề khoa học.", 0.25, 2, 3, new Guid("00000000-0000-0000-0000-00000000000f"), "Hợp đồng Thiết kế Hình Ảnh Khoa Học - Dự Án Phim Ngắn", 4, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000.0 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000003a") }
                });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-00000000000f") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000f") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001b") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001b") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000001e") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000001f") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000001f") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-00000000001f") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000021") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000021") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000021") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000021") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000021") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000024") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000024") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000024") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000025") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002f"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003f"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004f"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-00000000000f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-00000000000f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000011") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000013") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000014") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000016") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000001e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000001f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000001f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-00000000001f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000020") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000020") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000020") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000021") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000021") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000021") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000021") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000021") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000024") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000024") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000024") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001a"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001c"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001e"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000025") });

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001a"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001b"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001c"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001d"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001e"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "SoftwareUsed",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "SoftwareUsed",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003a"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001a"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001c"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001e"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                columns: new[] { "Avatar", "Username" },
                values: new object[] { "https://i.pinimg.com/564x/8f/52/88/8f5288392e58e7f69adecfdd1bb1d896.jpg", "ngothanhtu" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Avatar", "Bio" },
                values: new object[] { "https://i.pinimg.com/564x/10/3a/ed/103aed482f200ba1af9a50a2392a83f0.jpg", "Tôi là một thiết kế đồ họa trẻ tuổi nhưng tài năng, đã tham gia vào nhiều dự án sáng tạo và độc đáo." });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "Avatar",
                value: "https://i.pinimg.com/564x/7b/78/42/7b784268d117a6d57a8d9a83c7eaa977.jpg");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "Bio",
                value: "Tôi là một họa sĩ nổi tiếng với phong cách nghệ thuật độc đáo và sáng tạo. Đã tham gia vào nhiều triển lãm nghệ thuật quốc tế và được biết đến với các tác phẩm nổi bật.");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ViewCount",
                value: 344);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ViewCount",
                value: 638);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Thumbnail",
                value: "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Thumbnail",
                value: "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedBy", "IsAIGenerated" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), false });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống", "Hành trình tìm kiếm đam mê" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "ViewCount",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "ViewCount",
                value: 564);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "ThumbnailName",
                value: "00000000-0000-0000-0000-000000000011_t.jpg");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedBy", "LicenseTypeId", "ThumbnailName", "ViewCount" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000008"), "00000000-0000-0000-0000-000000000012_t.jpg", 345 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), "00000000-0000-0000-0000-00000000000e_i0.jpg", "https://i.pinimg.com/originals/b5/7e/14/b57e14aa401d41db2072d1b0ccfbde2b.jpg" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), "00000000-0000-0000-0000-00000000000e_i2.jpg", "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), "00000000-0000-0000-0000-00000000000f_i1.jpg", "https://i.pinimg.com/originals/b5/d4/7e/b5d47e1cf4555983a8017e59409b4d4a.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001_i0.jpg", "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000002_i0.jpg", "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000004_i0.jpg", "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), "00000000-0000-0000-0000-000000000005_i0.jpg", "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), "00000000-0000-0000-0000-000000000006_i0.jpg", "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), "00000000-0000-0000-0000-000000000009_i0.jpg", "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), "00000000-0000-0000-0000-000000000010_i0.jpg", "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), "00000000-0000-0000-0000-000000000011_i0.jpg", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i0.jpg?alt=media&token=e9a93f6f-4bcf-4517-824a-dacd402bdcec", 0 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), "00000000-0000-0000-0000-000000000011_i1.jpg", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i1.jpg?alt=media&token=3442240e-37f5-42f9-be58-5c359ebcde5c", 1 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), "00000000-0000-0000-0000-000000000012_i0.png", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "ArtworkId", "ImageName", "Location" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), "00000000-0000-0000-0000-000000000012_i1.png", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F2.png?alt=media&token=10e991c2-11ac-469b-9933-3b223fe17f5b" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), "00000000-0000-0000-0000-000000000012_i3.png", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F4.png?alt=media&token=53a9b98e-1875-48d6-a880-6b935081afe5", 3 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), "00000000-0000-0000-0000-000000000012_i4.png", "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F6.png?alt=media&token=3b05c46f-6ed0-42d6-aa84-1ef96a880f99", 5 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002a"),
                columns: new[] { "ArtworkId", "ImageName", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), "00000000-0000-0000-0000-000000000013_i0.png", "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg", 0 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000e"), null, "00000000-0000-0000-0000-00000000000e_i1.jpg", null, null, "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000f"), null, "00000000-0000-0000-0000-00000000000f_i0.jpg", null, null, "https://i.pinimg.com/originals/db/93/a1/db93a131d59201ed997d606ea33c4933.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000008"), null, "00000000-0000-0000-0000-000000000008_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000003_i0.jpg", null, null, "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007"), null, "00000000-0000-0000-0000-000000000007_i0.jpg", null, null, "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-00000000000a"), null, "00000000-0000-0000-0000-00000000000a_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000000b"), null, "00000000-0000-0000-0000-00000000000b_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000011"), null, "00000000-0000-0000-0000-000000000011_i2.jpg", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i2.jpg?alt=media&token=4d6ad124-294d-4059-b21d-a37cfb3d0c6a", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i2.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F3.png?alt=media&token=13f47f61-2372-4b87-b8f4-806c5ef956ee", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i4.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F5.png?alt=media&token=4d9137a2-5836-4cee-8e36-c1b87f9236c6", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Text",
                value: "Hellooooo bạn");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Text",
                value: "Hellooooo 2");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Text",
                value: "Hellooooo 3");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Text",
                value: "Hellooooo 4");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Text",
                value: "Hellooooo 5");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Text",
                value: "Hellooooo 6");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "Text",
                value: "Hellooooo 7");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Text",
                value: "Hellooooo 8");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Text",
                value: "Hellooooo 9");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "Text",
                value: "Hellooooo 10");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Text",
                value: "Hello from the sea.");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DeliveryTime", "Description", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[] { "1 - 2 tuần", "Mô tả Dịch vụ in ấn", 1, 1, "Dịch vụ in ấn", 50000.0, "https://channel.mediacdn.vn/2022/3/17/photo-1-1647512803989607433836.jpg" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DeliveryTime", "Description", "ServiceName", "Thumbnail" },
                values: new object[] { "3 - 4 tuần", "Mô tả Dịch vụ quản lý dự án", "Dịch vụ quản lý dự án", "https://www.inandaiduong.com/wp-content/uploads/2015/01/dich-vu-thiet-ke-in-an.jpg" });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "TagName",
                value: "Chủ đề xã hội");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "TagName",
                value: "Minimalism");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "TagName",
                value: "Động vật hoang dã");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "TagName",
                value: "Nền tảng");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "TagName",
                value: "Chủ đề khoa học");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "TagName",
                value: "Giao thông");
        }
    }
}
