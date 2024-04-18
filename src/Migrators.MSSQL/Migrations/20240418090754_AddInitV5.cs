using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Bio", "Fullname" },
                values: new object[] { "Tôi là người dùng, không có gì đặc biệt", "Nguyễn Văn A" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                columns: new[] { "Bio", "Fullname", "Username" },
                values: new object[] { "Một nhiếp ảnh gia tự xưng, thích du lịch, chụp nhiều bức ảnh độc đáo về văn hóa và cảnh đẹp Việt Nam và thế giới.", "Lê Văn Tân", "levantan" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address", "ArtisticStyle", "Avatar", "Bio", "Birthdate", "CreatedBy", "DeletedBy", "DeletedOn", "Email", "Fullname", "LastModificatedBy", "Password", "Role", "Username", "VerifiedOn" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000018"), null, null, "https://i.pinimg.com/564x/af/65/88/af6588a1cb6be3602190e4c223b79318.jpg", "Living and working in Japan / big fan of Key (Kagikko - 鍵っ子). A guy of social, cultural, and natural.", null, null, null, null, "minhhuy@example.com", "Trần Nguyễn Minh Huy", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "minhhuy", null },
                    { new Guid("00000000-0000-0000-0000-000000000019"), null, null, "https://i.pinimg.com/564x/d9/03/0a/d9030a5696d2507a1dfb38a686ac93c2.jpg", "Nole của công ty NaiNovel - công ty game đầu hàng Việt Nam", null, null, null, null, "manhkbrady@example.com", "Nguyễn Đức Mạnh", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "manhkbrady", null }
                });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "Thumbnail" },
                values: new object[] { new DateTime(2023, 12, 2, 9, 37, 42, 345, DateTimeKind.Local), "https://i.pinimg.com/736x/8d/f7/be/8df7be5e052e97b824e6b0f783309161.jpg" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 3, 22, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 20, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 5, 15, 30, 3, 678, DateTimeKind.Local), 2063 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 7, 30, 15, 567, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 12, 40, 28, 901, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 9, 1, 30, 15, 567, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 1, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 4, 20, 10, 234, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 20, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedOn", "Thumbnail" },
                values: new object[] { new DateTime(2023, 12, 11, 15, 30, 3, 678, DateTimeKind.Local), "https://cdn.pixabay.com/photo/2024/02/03/11/41/ai-generated-8550098_1280.jpg" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 11, 9, 37, 42, 345, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 11, 9, 37, 42, 345, DateTimeKind.Local), 2034 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 15, 40, 28, 901, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 15, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 17, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedOn",
                value: new DateTime(2024, 1, 10, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedBy", "CreatedOn", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new DateTime(2023, 12, 12, 16, 30, 3, 678, DateTimeKind.Local), "Mặc dù nghe có vẻ không đặc biệt, nhưng việc xuất bản visual novel được cấp phép đầu tiên tại Việt Nam là một cột mốc quan trọng trong sự phát triển của thể loại cực kén người chơi này trong cộng đồng của tôi. Đây là một dự án tuyệt vời và tôi rất vinh dự được tham gia vào quá trình thực hiện.", "Hình ảnh giới thiệu nhân vật & Đếm ngược ra mắt game" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 18, 11, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 14, 0, 11, 3, 678, DateTimeKind.Local), 1725 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 21, 11, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 20, 15, 20, 45, 890, DateTimeKind.Local), 1564 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 21, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 22, 15, 20, 45, 890, DateTimeKind.Local), 1204 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 23, 15, 20, 45, 890, DateTimeKind.Local), 1462 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001a"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 20, 45, 890, DateTimeKind.Local), 1874 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001b"),
                columns: new[] { "CreatedOn", "Title", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 25, 15, 20, 45, 890, DateTimeKind.Local), "Bầu trời", 1124 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001c"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 26, 15, 20, 45, 890, DateTimeKind.Local), 1666 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001d"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 27, 15, 20, 45, 890, DateTimeKind.Local), 1144 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001e"),
                column: "CreatedOn",
                value: new DateTime(2023, 12, 28, 15, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 29, 15, 20, 45, 890, DateTimeKind.Local), 1124 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedOn", "Thumbnail", "ViewCount" },
                values: new object[] { new DateTime(2023, 12, 29, 15, 20, 45, 890, DateTimeKind.Local), "https://cafebiz.cafebizcdn.vn/162123310254002176/2022/4/27/photo-1-1651050727352925703922.jpeg", 1968 });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CommentCount", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsAIGenerated", "LastModificatedBy", "LicenseTypeId", "LikeCount", "Note", "Privacy", "State", "Thumbnail", "ThumbnailName", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000021"), 0, new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2024, 1, 1, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://img3.gelbooru.com//images/db/56/db56fdd06f55f97ab9c884d5539e7e99.jpeg", "00000000-0000-0000-0000-000000000021_t.jpg", "Bạch thiếu nữ", 694 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), 0, new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2024, 1, 9, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F110149990_p0.jpg?alt=media&token=4668e7eb-f2ba-47f2-add9-96bb40acd22e", "00000000-0000-0000-0000-000000000026_t.jpg", "Bánh vòng", 814 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 12, 6, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2Fwp3790967.jpg?alt=media&token=203e265e-427f-4aa3-a664-2a39479bf61e", "00000000-0000-0000-0000-000000000027_t.jpg", "Rặng hoa anh đào", 518 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 12, 8, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/originals/57/da/1d/57da1db47a30fe8d608da6d3b25dfc08.jpg", "00000000-0000-0000-0000-000000000029_t.jpg", "Trời xanh", 1489 },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 12, 9, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/originals/56/a4/58/56a45858390e3726d2848d3efa696d6e.jpg", "00000000-0000-0000-0000-00000000002a_t.jpg", "Thung lũng xanh", 1034 },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2023, 12, 10, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/originals/51/59/8e/51598eb8f62f868e95556fc316873f05.jpg", "00000000-0000-0000-0000-00000000002b_t.jpg", "Đồng lúa", 1345 },
                    { new Guid("00000000-0000-0000-0000-00000000002c"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2023, 12, 11, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://i.pinimg.com/originals/33/b5/96/33b596908f23b4b2c3f3e64f032e51b6.png", "00000000-0000-0000-0000-00000000002c_t.jpg", "Hệ mặt trời", 145 },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2023, 12, 12, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://i.pinimg.com/originals/02/f2/28/02f2283c2a59d3e7d7287a95fae5c2f5.jpg", "00000000-0000-0000-0000-00000000002d_t.jpg", "Lập phương rubik", 595 },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), 0, new Guid("00000000-0000-0000-0000-000000000015"), new DateTime(2023, 12, 13, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://i.pinimg.com/originals/85/3e/bf/853ebff19a985aae38e65c8111e59ef8.png", "00000000-0000-0000-0000-00000000002e_t.jpg", "Ngọn hải đăng", 320 },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), 0, new Guid("00000000-0000-0000-0000-000000000015"), new DateTime(2024, 1, 20, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://i.pinimg.com/originals/d2/54/3a/d2543a52f10afe5696d68346d212d34e.jpg", "00000000-0000-0000-0000-00000000002f_t.jpg", "Mèo đen", 1020 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), 0, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 12, 15, 15, 20, 45, 890, DateTimeKind.Local), null, null, "\"The Nation of Vietnam is one, the People of Vietnam are one\", said by Hồ Chí Minh. The Vietnamese people's aspiration for independence, freedom, unity and happiness in the 20th century helped that nation win all wars of the aggressor ... ", false, null, new Guid("00000000-0000-0000-0000-000000000002"), 0, null, 0, 1, "https://i.pinimg.com/564x/41/e1/51/41e151608d67227d7265e7026faa48c1.jpg", "00000000-0000-0000-0000-000000000030_t.jpg", "Chủ tịch Hồ Chí Minh", 1645 },
                    { new Guid("00000000-0000-0000-0000-000000000031"), 0, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 27, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/originals/3d/e0/d0/3de0d0e553793ec3ee39cf1e7404e96e.jpg", "00000000-0000-0000-0000-000000000031_t.jpg", "Võ Nguyên Giáp", 1999 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), 0, new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 12, 17, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/564x/49/40/56/494056c9b3f314dad493bac63265f296.jpg", "00000000-0000-0000-0000-000000000032_t.jpg", "4575", 672 },
                    { new Guid("00000000-0000-0000-0000-000000000033"), 0, new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2023, 12, 20, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Travo Apps - Bộ công cụ giao diện người dùng cho Đặt vé máy bay và Khách sạn du lịch", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/1e/6f/85/1e6f852b5f25cd76c962c5affc55fcef.jpg", "00000000-0000-0000-0000-000000000033_t.jpg", "Travo Apps - UI KIT for Travel Flight and Hotel", 1499 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), 0, new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2024, 1, 6, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Thiết kế giao diện người dùng (UI) cho ứng dụng di động MyNovel, một nền tảng đọc truyện trực tuyến Thái Lan cho mọi loại tiểu thuyết tuyệt vời, sách điện tử và truyện tranh. Nó cập nhật nội dung theo dạng kịch bản hàng ngày và nhiều hơn nữa.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/18/57/2c/18572cd01747f618fbf837b7b4459437.jpg", "00000000-0000-0000-0000-000000000034_t.jpg", "MyNovel Mobile App UI", 1734 },
                    { new Guid("00000000-0000-0000-0000-000000000035"), 0, new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2023, 12, 22, 15, 20, 45, 890, DateTimeKind.Local), null, null, "tái thiết kế ứng dụng gặp gỡ người mới phổ biến nhất thế giới. Tinder là một ứng dụng cho phép người dùng vuốt sang trái hoặc phải để thích hoặc không thích các hồ sơ khác dựa trên ảnh, tiểu sử ngắn và sở thích chung. Khi hai người dùng \"match\" (bật cặp) với nhau thì họ có thể nhắn tin.", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://mir-s3-cdn-cf.behance.net/project_modules/1400/8cf9b997945993.5ee39b4959c00.jpg", "00000000-0000-0000-0000-000000000035_t.jpg", "Tinder mobile app redesign", 1499 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2023, 12, 23, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/66/b8/59/66b859b3949564d6e3f63cfcf2b6ef93.jpg", "00000000-0000-0000-0000-000000000036_t.jpg", "Góc phố Nhật Bản", 1599 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2023, 12, 24, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/564x/c8/a1/5f/c8a15ff316f7c74b789d21651b0891f8.jpg", "00000000-0000-0000-0000-000000000037_t.jpg", "Sapa mộng mer", 539 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2024, 1, 13, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Bãi tắm đảo Bé Lý Sơn nơi checkin sống ảo đúng chất", false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/564x/61/9f/65/619f65d4700c390f1e47ab42237ce450.jpg", "00000000-0000-0000-0000-000000000038_t.jpg", "Bãi tắm đảo Bé huyện đảo Lý Sơn", 999 },
                    { new Guid("00000000-0000-0000-0000-000000000039"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2024, 2, 1, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Looking for the best island to visit in Vietnam? This is the ultimate guide to visiting the Con Dao Islands. Find out what makes Con Dao is a must-visit!", false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/564x/ff/78/08/ff7808be1114e07dc1065245bd8bfc7f.jpg", "00000000-0000-0000-0000-000000000039_t.jpg", "Côn đảo, Việt Nam", 919 },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2023, 12, 27, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Review Landmark 81 - tòa nhà cao và sang trọng bậc nhất Việt Nam", false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://ik.imagekit.io/tvlk/blog/2024/01/landmark-81-3-841x1024.jpg?tr=dpr-2,w-675", "00000000-0000-0000-0000-00000000003a_t.jpg", "Landmark 81", 231 },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), 0, new Guid("00000000-0000-0000-0000-00000000000d"), new DateTime(2023, 12, 28, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Bãi biển Mỹ Khê Đà Nẵng - Địa điểm du lịch nổi tiếng tại Việt Nam", false, null, new Guid("00000000-0000-0000-0000-000000000008"), 0, null, 0, 1, "https://i.pinimg.com/564x/78/37/52/783752783478df60a339c4389697fe88.jpg", "00000000-0000-0000-0000-00000000003b_t.jpg", "Bãi biển Mỹ Khê", 999 },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), 0, new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2023, 12, 29, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Lỗ đen hay hố đen, là một vùng không–thời gian nơi trường hấp dẫn mạnh đến mức không có gì—không hạt vật chất hay cả bức xạ điện từ như ánh sáng có thể thoát khỏi nó.", false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/564x/d2/d1/17/d2d1176fbec2f7573eb1023c518e1105.jpg", "00000000-0000-0000-0000-00000000003c_t.jpg", "Hố Đen", 1899 },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2023, 12, 30, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Adorable 3D Character by AI. Follow for more!", false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/564x/d4/37/b3/d437b301b2408a5772d9be18d2dcbdee.jpg", "00000000-0000-0000-0000-00000000003d_t.jpg", "Thiết kế nhân vật 3D", 1562 },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2023, 12, 31, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Geralt of Rivia (tiếng Ba Lan: Geralt z Rivii) là một witcher và là nhân vật chính trong loạt tiểu thuyết The Witcher của nhà văn Andrzej Sapkowski", false, null, new Guid("00000000-0000-0000-0000-000000000004"), 0, null, 0, 1, "https://i.pinimg.com/736x/a9/5c/0f/a95c0f2de7561a34fbccc7af102b1af5.jpg", "00000000-0000-0000-0000-00000000003e_t.jpg", "Geralt xứ Rivia", 1262 },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2024, 1, 5, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Ai Representation of the Dragonborn from Elderscrolls Skyrim wearing daedric Armor", true, null, new Guid("00000000-0000-0000-0000-000000000004"), 0, null, 0, 1, "https://i.pinimg.com/736x/68/18/e5/6818e59fe9c1b059d679cbf35ab122c9.jpg", "00000000-0000-0000-0000-00000000003e_t.jpg", "The Dragonborn Daedric Armor", 835 },
                    { new Guid("00000000-0000-0000-0000-000000000040"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2024, 1, 7, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000005"), 0, null, 0, 1, "https://i.pinimg.com/originals/2b/ef/bd/2befbd3f91aa23db55eea433151c7992.jpg", "00000000-0000-0000-0000-000000000040_t.jpg", "Giáp thiên thần", 999 },
                    { new Guid("00000000-0000-0000-0000-000000000041"), 0, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2024, 1, 8, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/564x/00/ed/65/00ed65b58c95c4d694fc95598af0a885.jpg", "00000000-0000-0000-0000-000000000041_t.jpg", "Hoàng hôn", 452 },
                    { new Guid("00000000-0000-0000-0000-000000000042"), 0, new Guid("00000000-0000-0000-0000-00000000000f"), new DateTime(2024, 2, 9, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/564x/25/dc/d6/25dcd6a770856b37bdd3fd69551d626d.jpg", "00000000-0000-0000-0000-000000000042_t.jpg", "Ngẫu hứng phát họa", 1052 },
                    { new Guid("00000000-0000-0000-0000-000000000043"), 0, new Guid("00000000-0000-0000-0000-00000000000f"), new DateTime(2024, 2, 10, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/736x/d1/f7/e1/d1f7e116c4dc23c61f9523cea80ee909.jpg", "00000000-0000-0000-0000-000000000043_t.jpg", "Cô gái vàng", 599 },
                    { new Guid("00000000-0000-0000-0000-000000000044"), 0, new Guid("00000000-0000-0000-0000-00000000000f"), new DateTime(2024, 1, 15, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/736x/cf/7e/ff/cf7eff78ddcdeeed6b6074bd441eb721.jpg", "00000000-0000-0000-0000-000000000044_t.jpg", "Chàng trai", 654 },
                    { new Guid("00000000-0000-0000-0000-000000000045"), 0, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2024, 1, 20, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000003"), 0, null, 0, 1, "https://i.pinimg.com/564x/47/3e/f9/473ef931430e161d83f2aa5c8844d56a.jpg", "00000000-0000-0000-0000-000000000045_t.jpg", "Red dead Redemption", 654 },
                    { new Guid("00000000-0000-0000-0000-000000000046"), 0, new Guid("00000000-0000-0000-0000-00000000000a"), new DateTime(2024, 1, 25, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Universal / Fantasy Pixel Art GUI Kit for your new project, featuring Windowed and Fullscreen views to fit all your needs!", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://assetstorev1-prd-cdn.unity3d.com/key-image/da31eccd-b255-4898-bec2-2e1b1eb39092.webp", "00000000-0000-0000-0000-000000000046_t.jpg", "Pixel Art GUI / UI Kit + 151 icons!", 1444 },
                    { new Guid("00000000-0000-0000-0000-000000000047"), 0, new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 1, 30, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://pbs.twimg.com/media/GLZZrVhbUAEie26?format=png&name=900x900", "00000000-0000-0000-0000-000000000047_t.jpg", "Visual Studio Code Redesign", 928 },
                    { new Guid("00000000-0000-0000-0000-000000000048"), 0, new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2024, 2, 5, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Mẫu thiết kế ứng dụng di động đẹp mắt cho các dự án của bạn", false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/2c/5d/80/2c5d80e9c0240a65d6397f9991352855.jpg", "00000000-0000-0000-0000-000000000048_t.jpg", "Fluid Background", 109 },
                    { new Guid("00000000-0000-0000-0000-000000000049"), 0, new Guid("00000000-0000-0000-0000-00000000000c"), new DateTime(2023, 12, 5, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/71/01/da/7101da0949d85dfbf7c24200f1fcbdfd.jpg", "00000000-0000-0000-0000-000000000048_t.jpg", "Moona hoshinova", 376 },
                    { new Guid("00000000-0000-0000-0000-00000000004a"), 0, new Guid("00000000-0000-0000-0000-000000000014"), new DateTime(2024, 1, 10, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, true, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/61/29/93/61299356ecd161b0ac86c94869960084.jpg", "00000000-0000-0000-0000-00000000004a_t.jpg", "Artificial Intelligence Robot Cyberpunk High Tech Sci-fi Poster", 567 },
                    { new Guid("00000000-0000-0000-0000-00000000004b"), 0, new Guid("00000000-0000-0000-0000-000000000014"), new DateTime(2024, 2, 1, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/a3/ef/9c/a3ef9c4379f92f56607f1f685e7835ce.jpg", "00000000-0000-0000-0000-00000000004b_t.jpg", "Intelligent Robots Metaverse Cyberpunk Cat Robot Poster", 833 },
                    { new Guid("00000000-0000-0000-0000-00000000004c"), 0, new Guid("00000000-0000-0000-0000-000000000014"), new DateTime(2024, 1, 15, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i.pinimg.com/564x/19/d5/fb/19d5fbfe0a970510bfe47aa148e0b71e.jpg", "00000000-0000-0000-0000-00000000004c_t.jpg", "Cyberpunk Robot Poster", 1133 }
                });

            migrationBuilder.InsertData(
                table: "Block",
                columns: new[] { "BlockedId", "BlockingId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Collection",
                columns: new[] { "Id", "CollectionName", "CreatedBy", "CreatedOn", "Privacy" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Trò chơi yêu thích", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Hoàng hôn", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ArtworkId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "LastModificatedBy", "ReplyId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005"), "Đây là một bức tranh rất đẹp", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000005"), "Minh hoạ xuất sắc", new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000005"), "10 điểm", new Guid("00000000-0000-0000-0000-00000000000a"), new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000005"), "So peak", new Guid("00000000-0000-0000-0000-00000000000b"), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Location",
                value: "https://i.pinimg.com/736x/8d/f7/be/8df7be5e052e97b824e6b0f783309161.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "Location",
                value: "https://cdn.pixabay.com/photo/2024/02/03/11/41/ai-generated-8550098_1280.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                column: "Location",
                value: "https://cafebiz.cafebizcdn.vn/162123310254002176/2022/4/27/photo-1-1651050727352925703922.jpeg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                column: "Location",
                value: "https://cafebiz.cafebizcdn.vn/162123310254002176/2022/4/27/photo-1-16510507247002018514994.jpeg");

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000001_i1.jpg", null, null, "https://i.pinimg.com/564x/18/f5/01/18f50109029ade270f0759724a0c19f1.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Detail",
                value: "Dịch vụ xuất sắc");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "LastModificatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "LastModificatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "LastModificatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "LastModificatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "LastModificatedOn",
                value: null);

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tháng", "Bạn đang muốn tạo ra một ứng dụng di động ấn tượng và thu hút người dùng? Figma chính là công cụ hoàn hảo để biến ý tưởng của bạn thành hiện thực.", null, 3, 2, "Thiết kế Mobile App bằng Figma", 80000.0, "https://bs-uploads.toptal.io/blackfish-uploads/components/seo/5914508/og_image/optimized/figma-design-tool-e09b94850458e37b90442beb2a9192cc.png" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tuần", "Mang đến sức sống cho những thế giới ảo diệu! Bạn đang tìm kiếm dịch vụ thiết kế nhân vật game 3D chất lượng cao để nâng tầm dự án của mình ? Hãy đến với chúng tôi!", null, 1, 2, "Thiết kế nhân vật game 3D", 30000.0, "https://i.pinimg.com/564x/d4/37/b3/d437b301b2408a5772d9be18d2dcbdee.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "TagName",
                value: "Nhật Bản");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "TagName",
                value: "AI Tạo Sinh");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000026"), "Dễ thương" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "Phát họa" }
                });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000000f") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000001c") }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CommentCount", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsAIGenerated", "LastModificatedBy", "LicenseTypeId", "LikeCount", "Note", "Privacy", "State", "Thumbnail", "ThumbnailName", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000022"), 0, new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2024, 1, 3, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.4gamer.net/games/411/G041111/20180227026/SS/002.jpg", "00000000-0000-0000-0000-000000000022_t.jpg", "Kushima Kamome", 634 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), 0, new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2024, 1, 5, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.4gamer.net/games/411/G041111/20180227026/SS/003.jpg", "00000000-0000-0000-0000-000000000023_t.jpg", "Ao Sorakado", 234 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), 0, new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2024, 1, 6, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.4gamer.net/games/411/G041111/20180227026/SS/004.jpg", "00000000-0000-0000-0000-000000000024_t.jpg", "Tsumugi Wenders", 345 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), 0, new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2024, 1, 9, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://www.4gamer.net/games/411/G041111/20180227026/SS/005.jpg", "00000000-0000-0000-0000-000000000025_t.jpg", "Shiroha Naruse", 370 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), 0, new Guid("00000000-0000-0000-0000-000000000018"), new DateTime(2023, 12, 7, 15, 20, 45, 890, DateTimeKind.Local), null, null, null, false, null, new Guid("00000000-0000-0000-0000-000000000001"), 0, null, 0, 1, "https://i0.wp.com/images1.wikia.nocookie.net/mydata/vi/images/b/be/Anemoi_main_viet.png?ssl=1", "00000000-0000-0000-0000-000000000028_t.jpg", "Một lời hứa cuốn trong làn gió", 327 }
                });

            migrationBuilder.InsertData(
                table: "Bookmark",
                columns: new[] { "ArtworkId", "CollectionId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000e") }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000053"), new Guid("00000000-0000-0000-0000-000000000021"), null, "00000000-0000-0000-0000-000000000021_i0.jpg", null, null, "https://img3.gelbooru.com//images/db/56/db56fdd06f55f97ab9c884d5539e7e99.jpeg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000005a"), new Guid("00000000-0000-0000-0000-000000000026"), null, "00000000-0000-0000-0000-000000000026_i0.jpg", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F110149990_p0.jpg?alt=media&token=4668e7eb-f2ba-47f2-add9-96bb40acd22e", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000005c"), new Guid("00000000-0000-0000-0000-000000000027"), null, "00000000-0000-0000-0000-000000000027_i0.jpg", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2Fwp3790967.jpg?alt=media&token=203e265e-427f-4aa3-a664-2a39479bf61e", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000061"), new Guid("00000000-0000-0000-0000-000000000029"), null, "00000000-0000-0000-0000-000000000029_i0.jpg", null, null, "https://i.pinimg.com/originals/57/da/1d/57da1db47a30fe8d608da6d3b25dfc08.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000062"), new Guid("00000000-0000-0000-0000-00000000002a"), null, "00000000-0000-0000-0000-00000000002a_i0.jpg", null, null, "https://i.pinimg.com/originals/56/a4/58/56a45858390e3726d2848d3efa696d6e.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000063"), new Guid("00000000-0000-0000-0000-00000000002b"), null, "00000000-0000-0000-0000-00000000002b_i0.jpg", null, null, "https://i.pinimg.com/originals/51/59/8e/51598eb8f62f868e95556fc316873f05.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000064"), new Guid("00000000-0000-0000-0000-00000000002c"), null, "00000000-0000-0000-0000-00000000002c_i0.jpg", null, null, "https://i.pinimg.com/originals/33/b5/96/33b596908f23b4b2c3f3e64f032e51b6.png", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000065"), new Guid("00000000-0000-0000-0000-00000000002d"), null, "00000000-0000-0000-0000-00000000002d_i0.jpg", null, null, "https://i.pinimg.com/originals/02/f2/28/02f2283c2a59d3e7d7287a95fae5c2f5.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000066"), new Guid("00000000-0000-0000-0000-00000000002e"), null, "00000000-0000-0000-0000-00000000002e_i0.jpg", null, null, "https://i.pinimg.com/originals/85/3e/bf/853ebff19a985aae38e65c8111e59ef8.png", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000067"), new Guid("00000000-0000-0000-0000-00000000002f"), null, "00000000-0000-0000-0000-00000000002f_i0.jpg", null, null, "https://i.pinimg.com/originals/d2/54/3a/d2543a52f10afe5696d68346d212d34e.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000068"), new Guid("00000000-0000-0000-0000-000000000030"), null, "00000000-0000-0000-0000-000000000030_i0.jpg", null, null, "https://i.pinimg.com/564x/41/e1/51/41e151608d67227d7265e7026faa48c1.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000069"), new Guid("00000000-0000-0000-0000-000000000031"), null, "00000000-0000-0000-0000-000000000031_i0.jpg", null, null, "https://i.pinimg.com/originals/3d/e0/d0/3de0d0e553793ec3ee39cf1e7404e96e.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000006a"), new Guid("00000000-0000-0000-0000-000000000032"), null, "00000000-0000-0000-0000-000000000032_i0.jpg", null, null, "https://i.pinimg.com/564x/49/40/56/494056c9b3f314dad493bac63265f296.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000006b"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i0.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103603.png", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000006c"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i1.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103638.png", 1 },
                    { new Guid("00000000-0000-0000-0000-00000000006d"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i2.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103637.png", 2 },
                    { new Guid("00000000-0000-0000-0000-00000000006e"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i3.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103566.png", 3 },
                    { new Guid("00000000-0000-0000-0000-00000000006f"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i3.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103592.png", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000070"), new Guid("00000000-0000-0000-0000-000000000033"), null, "00000000-0000-0000-0000-000000000033_i3.jpg", null, null, "https://images.ui8.net/uploads/frame-12_1580960103587.png", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000071"), new Guid("00000000-0000-0000-0000-000000000034"), null, "00000000-0000-0000-0000-000000000034_i0.jpg", null, null, "https://www.sinthaistudio.com/wp-content/uploads/2021/08/MN1-uai-516x568.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000072"), new Guid("00000000-0000-0000-0000-000000000034"), null, "00000000-0000-0000-0000-000000000034_i1.jpg", null, null, "https://www.sinthaistudio.com/wp-content/uploads/2021/08/MN2.jpg", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000073"), new Guid("00000000-0000-0000-0000-000000000034"), null, "00000000-0000-0000-0000-000000000034_i2.jpg", null, null, "https://www.sinthaistudio.com/wp-content/uploads/2021/08/MN3.jpg", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000074"), new Guid("00000000-0000-0000-0000-000000000035"), null, "00000000-0000-0000-0000-000000000034_i3.jpg", null, null, "https://www.sinthaistudio.com/wp-content/uploads/2021/08/MN4.jpg", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000075"), new Guid("00000000-0000-0000-0000-000000000035"), null, "00000000-0000-0000-0000-000000000035_i0.jpg", null, null, "https://mir-s3-cdn-cf.behance.net/project_modules/1400/8cf9b997945993.5ee39b4959c00.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000076"), new Guid("00000000-0000-0000-0000-000000000036"), null, "00000000-0000-0000-0000-000000000036_i0.jpg", null, null, "https://i.pinimg.com/564x/66/b8/59/66b859b3949564d6e3f63cfcf2b6ef93.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000077"), new Guid("00000000-0000-0000-0000-000000000037"), null, "00000000-0000-0000-0000-000000000037_i0.jpg", null, null, "https://i.pinimg.com/564x/c8/a1/5f/c8a15ff316f7c74b789d21651b0891f8.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000078"), new Guid("00000000-0000-0000-0000-000000000038"), null, "00000000-0000-0000-0000-000000000038_i0.jpg", null, null, "https://i.pinimg.com/564x/61/9f/65/619f65d4700c390f1e47ab42237ce450.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000079"), new Guid("00000000-0000-0000-0000-000000000039"), null, "00000000-0000-0000-0000-000000000039_i0.jpg", null, null, "https://i.pinimg.com/564x/ff/78/08/ff7808be1114e07dc1065245bd8bfc7f.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000007a"), new Guid("00000000-0000-0000-0000-00000000003a"), null, "00000000-0000-0000-0000-00000000003a_i0.jpg", null, null, "https://ik.imagekit.io/tvlk/blog/2024/01/landmark-81-3-841x1024.jpg?tr=dpr-2,w-675", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000007b"), new Guid("00000000-0000-0000-0000-00000000003b"), null, "00000000-0000-0000-0000-00000000003b_i0.jpg", null, null, "https://i.pinimg.com/564x/78/37/52/783752783478df60a339c4389697fe88.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000007c"), new Guid("00000000-0000-0000-0000-00000000003c"), null, "00000000-0000-0000-0000-00000000003c_i0.jpg", null, null, "https://i.pinimg.com/564x/d2/d1/17/d2d1176fbec2f7573eb1023c518e1105.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000007d"), new Guid("00000000-0000-0000-0000-00000000003d"), null, "00000000-0000-0000-0000-00000000003d_i0.jpg", null, null, "https://i.pinimg.com/564x/d4/37/b3/d437b301b2408a5772d9be18d2dcbdee.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000080"), new Guid("00000000-0000-0000-0000-00000000003e"), null, "00000000-0000-0000-0000-00000000003e_i0.jpg", null, null, "https://i.pinimg.com/736x/a9/5c/0f/a95c0f2de7561a34fbccc7af102b1af5.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000081"), new Guid("00000000-0000-0000-0000-00000000003f"), null, "00000000-0000-0000-0000-00000000003f_i0.jpg", null, null, "https://i.pinimg.com/736x/68/18/e5/6818e59fe9c1b059d679cbf35ab122c9.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000082"), new Guid("00000000-0000-0000-0000-000000000040"), null, "00000000-0000-0000-0000-000000000040_i0.jpg", null, null, "https://i.pinimg.com/originals/2b/ef/bd/2befbd3f91aa23db55eea433151c7992.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000083"), new Guid("00000000-0000-0000-0000-000000000041"), null, "00000000-0000-0000-0000-000000000041_i0.jpg", null, null, "https://i.pinimg.com/564x/00/ed/65/00ed65b58c95c4d694fc95598af0a885.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000084"), new Guid("00000000-0000-0000-0000-000000000042"), null, "00000000-0000-0000-0000-000000000042_i0.jpg", null, null, "https://i.pinimg.com/564x/25/dc/d6/25dcd6a770856b37bdd3fd69551d626d.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000085"), new Guid("00000000-0000-0000-0000-000000000043"), null, "00000000-0000-0000-0000-000000000043_i0.jpg", null, null, "https://i.pinimg.com/736x/d1/f7/e1/d1f7e116c4dc23c61f9523cea80ee909.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000086"), new Guid("00000000-0000-0000-0000-000000000044"), null, "00000000-0000-0000-0000-000000000044_i0.jpg", null, null, "https://i.pinimg.com/736x/cf/7e/ff/cf7eff78ddcdeeed6b6074bd441eb721.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000087"), new Guid("00000000-0000-0000-0000-000000000045"), null, "00000000-0000-0000-0000-000000000045_i0.jpg", null, null, "https://i.pinimg.com/564x/47/3e/f9/473ef931430e161d83f2aa5c8844d56a.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000088"), new Guid("00000000-0000-0000-0000-000000000046"), null, "00000000-0000-0000-0000-000000000046_i0.jpg", null, null, "https://assetstorev1-prd-cdn.unity3d.com/key-image/da31eccd-b255-4898-bec2-2e1b1eb39092.webp", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000089"), new Guid("00000000-0000-0000-0000-000000000046"), null, "00000000-0000-0000-0000-000000000046_i1.jpg", null, null, "https://assetstorev1-prd-cdn.unity3d.com/package-screenshot/f62a52ea-5ee7-406c-abcf-5b91970f964a.webp", 1 },
                    { new Guid("00000000-0000-0000-0000-00000000008a"), new Guid("00000000-0000-0000-0000-000000000046"), null, "00000000-0000-0000-0000-000000000046_i2.jpg", null, null, "https://assetstorev1-prd-cdn.unity3d.com/package-screenshot/f19fb81d-cfeb-41d5-a092-9b61d6530ba8.webp", 2 },
                    { new Guid("00000000-0000-0000-0000-00000000008b"), new Guid("00000000-0000-0000-0000-000000000046"), null, "00000000-0000-0000-0000-000000000046_i3.jpg", null, null, "https://assetstorev1-prd-cdn.unity3d.com/package-screenshot/1cb97919-ca37-40f4-90db-765eee1ff653.webp", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000090"), new Guid("00000000-0000-0000-0000-000000000047"), null, "00000000-0000-0000-0000-000000000047_i0.jpg", null, null, "https://pbs.twimg.com/media/GLZZrVhbUAEie26?format=png&name=900x900", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000093"), new Guid("00000000-0000-0000-0000-000000000048"), null, "00000000-0000-0000-0000-000000000048_i0.jpg", null, null, "https://i.pinimg.com/564x/2c/5d/80/2c5d80e9c0240a65d6397f9991352855.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000094"), new Guid("00000000-0000-0000-0000-000000000049"), null, "00000000-0000-0000-0000-000000000049_i0.jpg", null, null, "https://i.pinimg.com/564x/71/01/da/7101da0949d85dfbf7c24200f1fcbdfd.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000095"), new Guid("00000000-0000-0000-0000-00000000004a"), null, "00000000-0000-0000-0000-00000000004a_i0.jpg", null, null, "https://i.pinimg.com/564x/61/29/93/61299356ecd161b0ac86c94869960084.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000096"), new Guid("00000000-0000-0000-0000-00000000004b"), null, "00000000-0000-0000-0000-00000000004b_i0.jpg", null, null, "https://i.pinimg.com/564x/a3/ef/9c/a3ef9c4379f92f56607f1f685e7835ce.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000097"), new Guid("00000000-0000-0000-0000-00000000004c"), null, "00000000-0000-0000-0000-00000000004c_i0.jpg", null, null, "https://i.pinimg.com/564x/19/d5/fb/19d5fbfe0a970510bfe47aa148e0b71e.jpg", 0 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000008") }
                });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000035") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-00000000003a") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-00000000003a") }
                });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000f") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001a") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001b") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001b") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001b") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000001c") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000001d") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001e") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-00000000001e") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-00000000001e") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000024") },
                    { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000024") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000026") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000026") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000026") },
                    { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000026") },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000027") },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000027") },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000027") }
                });

            migrationBuilder.InsertData(
                table: "Bookmark",
                columns: new[] { "ArtworkId", "CollectionId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000054"), new Guid("00000000-0000-0000-0000-000000000022"), null, "00000000-0000-0000-0000-000000000022_i0.jpg", null, null, "https://www.4gamer.net/games/411/G041111/20180227026/SS/002.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000055"), new Guid("00000000-0000-0000-0000-000000000022"), null, "00000000-0000-0000-0000-000000000022_i1.jpg", null, null, "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2Ftenor.gif?alt=media&token=270214ac-b289-4608-ba5c-9ea68e7ae97a", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000056"), new Guid("00000000-0000-0000-0000-000000000023"), null, "00000000-0000-0000-0000-000000000023_i0.jpg", null, null, "https://www.4gamer.net/games/411/G041111/20180227026/SS/003.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000057"), new Guid("00000000-0000-0000-0000-000000000024"), null, "00000000-0000-0000-0000-000000000024_i0.jpg", null, null, "https://www.4gamer.net/games/411/G041111/20180227026/SS/004.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000058"), new Guid("00000000-0000-0000-0000-000000000025"), null, "00000000-0000-0000-0000-000000000025_i0.jpg", null, null, "https://www.4gamer.net/games/411/G041111/20180227026/SS/005.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000060"), new Guid("00000000-0000-0000-0000-000000000028"), null, "00000000-0000-0000-0000-000000000028_i0.jpg", null, null, "https://i0.wp.com/images1.wikia.nocookie.net/mydata/vi/images/b/be/Anemoi_main_viet.png?ssl=1", 0 }
                });

            migrationBuilder.InsertData(
                table: "SoftwareDetail",
                columns: new[] { "ArtworkId", "SoftwareUsedId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000022") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Block",
                keyColumns: new[] { "BlockedId", "BlockingId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "Bookmark",
                keyColumns: new[] { "ArtworkId", "CollectionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000005a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000005c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006f"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000008a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000008b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000035") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000039") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "SoftwareDetail",
                keyColumns: new[] { "ArtworkId", "SoftwareUsedId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-00000000003a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000000f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000000f") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000012") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000012") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000012") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000013") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000014") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000016") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000016") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000016") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002e"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001a") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001b") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000001c") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003a"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003b"), new Guid("00000000-0000-0000-0000-00000000001d") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-00000000001e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-00000000001e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-00000000001e") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000020") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002a"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002b"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000022") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002d"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003d"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003e"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003f"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000023") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002c"), new Guid("00000000-0000-0000-0000-000000000024") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000003c"), new Guid("00000000-0000-0000-0000-000000000024") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000026") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000026") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000026") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-00000000002f"), new Guid("00000000-0000-0000-0000-000000000026") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000027") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000027") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000027") });

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002a"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002b"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002c"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002d"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002e"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000002f"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003a"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003b"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003c"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003d"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003e"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000003f"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004a"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004b"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000004c"));

            migrationBuilder.DeleteData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Bio", "Fullname" },
                values: new object[] { "Tôi là người dùng mặc định", "Người dùng mặc định" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                columns: new[] { "Bio", "Fullname", "Username" },
                values: new object[] { "Tôi là một nhiếp ảnh gia có tên tuổi, đã chụp nhiều bức ảnh độc đáo về văn hóa và cảnh đẹp Việt Nam.", "Lê Văn", "levan" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "Thumbnail" },
                values: new object[] { new DateTime(2023, 11, 2, 9, 37, 42, 345, DateTimeKind.Local), "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 3, 22, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 4, 20, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 5, 15, 30, 3, 678, DateTimeKind.Local), 203 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 6, 7, 30, 15, 567, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 7, 12, 40, 28, 901, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 9, 1, 30, 15, 567, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 1, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 10, 4, 20, 10, 234, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 10, 20, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedOn", "Thumbnail" },
                values: new object[] { new DateTime(2023, 11, 11, 15, 30, 3, 678, DateTimeKind.Local), "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000c"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 11, 9, 37, 42, 345, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 11, 9, 37, 42, 345, DateTimeKind.Local), 234 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000e"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 15, 40, 28, 901, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000f"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 15, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 17, 55, 30, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 10, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedBy", "CreatedOn", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 12, 16, 30, 3, 678, DateTimeKind.Local), "The first ever licensed visual novel in Vietnam, which might not sound special, is a huge milestone in the development of this extremely niche genre in my community. Great stuffs, and it was an honor of mine to work with this.", "Countdown / character introduction images for a game release" });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 18, 11, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 14, 0, 11, 3, 678, DateTimeKind.Local), 725 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 21, 11, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 20, 15, 20, 45, 890, DateTimeKind.Local), 564 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 15, 30, 3, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 22, 15, 20, 45, 890, DateTimeKind.Local), 124 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 23, 15, 20, 45, 890, DateTimeKind.Local), 462 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001a"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 24, 15, 20, 45, 890, DateTimeKind.Local), 874 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001b"),
                columns: new[] { "CreatedOn", "Title", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 25, 15, 20, 45, 890, DateTimeKind.Local), "꒰𝙰𝚒 𝙰𝚛𝚝꒱ Wallpaper", 124 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001c"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 26, 15, 20, 45, 890, DateTimeKind.Local), 666 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001d"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 27, 15, 20, 45, 890, DateTimeKind.Local), 144 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001e"),
                column: "CreatedOn",
                value: new DateTime(2023, 11, 28, 15, 20, 45, 890, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000001f"),
                columns: new[] { "CreatedOn", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 29, 15, 20, 45, 890, DateTimeKind.Local), 124 });

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedOn", "Thumbnail", "ViewCount" },
                values: new object[] { new DateTime(2023, 11, 29, 15, 20, 45, 890, DateTimeKind.Local), "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png", 968 });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Location",
                value: "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "Location",
                value: "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                column: "Location",
                value: "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                column: "Location",
                value: "https://i.upanh.org/2024/04/17/image689a466ed577378c.png");

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Detail",
                value: "good");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "LastModificatedOn",
                value: new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "TagName",
                value: "Graffiti");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "TagName",
                value: "AI");
        }
    }
}
