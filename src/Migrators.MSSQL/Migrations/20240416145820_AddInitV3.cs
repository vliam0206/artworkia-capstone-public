using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDelivery",
                table: "Proposal",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "IsAIGenerated", "ViewCount" },
                values: new object[] { true, 344 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "IsAIGenerated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Thumbnail", "Title" },
                values: new object[] { "Minh họa cuộc chiến tiêu biểu của thời đại", "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg", "Chiến thắng Điện Biên Phủ" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ViewCount",
                value: 203);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ViewCount",
                value: 826);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                column: "ViewCount",
                value: 565);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "IsAIGenerated",
                value: true);

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
                column: "ViewCount",
                value: 344);

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CommentCount", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsAIGenerated", "LastModificatedBy", "LicenseTypeId", "LikeCount", "Note", "Privacy", "State", "Thumbnail", "ThumbnailName", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000012"), 0, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 12, 16, 30, 3, 678, DateTimeKind.Local), null, null, "The first ever licensed visual novel in Vietnam, which might not sound special, is a huge milestone in the development of this extremely niche genre in my community. Great stuffs, and it was an honor of mine to work with this.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc", "00000000-0000-0000-0000-000000000011_t.jpg", "Countdown / character introduction images for a game release", 1011 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 11, 13, 18, 11, 3, 678, DateTimeKind.Local), null, null, "Là một họa sĩ được sinh ra và lớn lên khi đất nước đã thống nhất, Mai Duy Minh đã cố gắng hết sức có thể trong việc tìm kiếm một câu trả lời cho riêng cá nhân anh về cách mà các thế hệ người Việt Nam bền bỉ đi qua mọi gian khổ để bảo vệ độc lập dân tộc. Tất cả những nỗ lực tìm kiếm và lắng nghe mọi vang vọng từ quá khứ chiến đấu anh dũng ấy của cha anh đi trước đã được hội tụ trong bức tranh “Điện Biên Phủ”..", false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg", "00000000-0000-0000-0000-000000000012_t.jpg", "Tranh sơn dầu Đại tướng Võ Nguyên Giáp", 345 }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ParentCategory",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "ParentCategory" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "Phác họa", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "Thiết kế nhân vật", new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000a") }
                });

            migrationBuilder.InsertData(
                table: "Follow",
                columns: new[] { "FollowedId", "FollowingId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i0.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i2.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Location",
                value: "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ActualDelivery", "TargetDelivery" },
                values: new object[] { new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i0.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i1.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F2.png?alt=media&token=10e991c2-11ac-469b-9933-3b223fe17f5b", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i2.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F3.png?alt=media&token=13f47f61-2372-4b87-b8f4-806c5ef956ee", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i3.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F4.png?alt=media&token=53a9b98e-1875-48d6-a880-6b935081afe5", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i4.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F5.png?alt=media&token=4d9137a2-5836-4cee-8e36-c1b87f9236c6", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000012"), null, "00000000-0000-0000-0000-000000000012_i4.png", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F6.png?alt=media&token=3b05c46f-6ed0-42d6-aa84-1ef96a880f99", 5 },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000013"), null, "00000000-0000-0000-0000-000000000013_i0.png", null, null, "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "Follow",
                keyColumns: new[] { "FollowedId", "FollowingId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "Follow",
                keyColumns: new[] { "FollowedId", "FollowingId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "Follow",
                keyColumns: new[] { "FollowedId", "FollowingId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "Follow",
                keyColumns: new[] { "FollowedId", "FollowingId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002a"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DropColumn(
                name: "ActualDelivery",
                table: "Proposal");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "IsAIGenerated", "ViewCount" },
                values: new object[] { false, 99 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "IsAIGenerated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Thumbnail", "Title" },
                values: new object[] { "Minh họa những cuộc chiến tiêu biểu của thời đại", "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain", "Vẻ đẹp của lịch sử" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ViewCount",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ViewCount",
                value: 86);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                column: "ViewCount",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "IsAIGenerated",
                value: false);

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
                column: "ViewCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ParentCategory",
                value: null);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i2.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageName",
                value: "00000000-0000-0000-0000-00000000000e_i3.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Location",
                value: "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proposal",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "TargetDelivery",
                value: new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
