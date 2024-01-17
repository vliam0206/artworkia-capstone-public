using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Avatar", "Bio", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "Fullname", "LastModificatedBy", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg", null, null, new DateTime(2023, 10, 27, 19, 23, 47, 890, DateTimeKind.Local), null, null, "thong@example.com", "Nguyễn Trung Thông", null, "BCpA8roVqTkU54PKIBXU4Iyl3YqyF5wYPagAXZ/1HYFEB9dh", 2, "thong" },
                    { new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg", null, null, new DateTime(2023, 10, 15, 17, 15, 47, 890, DateTimeKind.Local), null, null, "lamlam@example.com", "Trúc Lam Võ", null, "P9i8PUWQ4DnT6Dnstg7HEXTlnFUDoZFTNJopEJ4UxxoK3zRn", 2, "lamlam" },
                    { new Guid("7d580000-c214-88a4-5141-08dc1445b3e3"), "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg", null, null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "admin@example.com", "Quản trị viên hệ thống", null, "tmb/sYLga1PDxUtRiIEU4YJtaG2HN58av/VA2S/8v19GLbSx", 0, "admin" },
                    { new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg", null, null, new DateTime(2023, 10, 30, 10, 21, 47, 890, DateTimeKind.Local), null, null, "phu@example.com", "Huỳnh Vạn Phú", null, "44p9oaVq2ED8i7Q6vKIaS//ynDYqhnLcHcX/W7sDDIa1m3v/", 2, "phuhuynh" },
                    { new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg", null, null, new DateTime(2023, 10, 21, 19, 20, 47, 890, DateTimeKind.Local), null, null, "hoanganh@example.com", "Đặng Hoàng Anh", null, "RZX95v+qA/O+EKXLkilrMbLW+cKQ7jekrOE9uwWE4fSupbQM", 2, "hoanganh" },
                    { new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg", null, null, new DateTime(2023, 10, 14, 12, 37, 42, 345, DateTimeKind.Local), null, null, "user@example.com", "Người dùng mặc định", null, "/Yvo/zNSPcJB+6Roi0BD6gR/tx9tPXSqrslB+3Zy0rwOC2lA", 2, "user" },
                    { new Guid("7d580000-c214-88a4-e5f6-08dc1445b3e2"), "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg", null, null, new DateTime(2023, 10, 14, 12, 37, 42, 345, DateTimeKind.Local), null, null, "mod@example.com", "Kiểm soát viên", null, "/yI89eEokmyCtc8FQcA8Salpuc2Gnv6+xvWUi9jfF3D56K8l", 1, "mod" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "ParentCategory" },
                values: new object[,]
                {
                    { new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3"), "In ấn", null },
                    { new Guid("490f5bd6-1a32-4e9b-9236-5794c97526e1"), "Đồ họa 3D", null },
                    { new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e"), "Minh hoạ", null },
                    { new Guid("6dfe4e90-98e1-43e5-b2c1-ef7fd9e6fb67"), "Đồ họa chuyển động", null },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), "Nhiếp ảnh", null },
                    { new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), "Thiết kế đồ họa", null },
                    { new Guid("a6d7e9b2-85af-4f01-bd97-2c3bbd3a7e09"), "Kiến trúc", null },
                    { new Guid("c51283f7-6d58-4a70-9bf2-13d3b5bc8456"), "UI/UX", null },
                    { new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5"), "Nghệ thuật số", null },
                    { new Guid("e839e134-9158-4d2d-a04f-503fdd2d2751"), "Quảng cáo", null },
                    { new Guid("e839e134-9158-4d2d-a04f-503fdd2d275e"), "Thiết kế sản phẩm", null },
                    { new Guid("f4e81ac1-1a6e-47c3-92fc-7a54ae95d689"), "Thời trang", null }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec1"), "Màu sắc" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2"), "Trừu tượng" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec3"), "Phong cảnh" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec4"), "Thiên nhiên" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), "Hình học" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec6"), "Anime" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec7"), "Chân dung" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8"), "Sáng tạo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9"), "Kỹ thuật số" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95eca"), "Graffiti" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb"), "Dự án cá nhân" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecc"), "Nghệ thuật số hóa" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecd"), "Thể thao" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ece"), "Chủ đề xã hội" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecf"), "Vintage" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed0"), "Ảo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed1"), "Minimalism" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed2"), "Figma" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed3"), "Mèo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed4"), "Động vật hoang dã" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed5"), "Nền tảng" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6"), "Nghệ thuật đương đại" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed7"), "Chủ đề khoa học" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed8"), "Giao thông" }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "Privacy", "Thumbnail", "ThumbnailName", "Title" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f5e"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 20, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha", null, 0, "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain", "35966d1a-9b08-4743-b1c3-474a58350f5e_t.jpg", "Tuyển tập minh hoạ sách tâm lý" },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 27, 15, 40, 28, 901, DateTimeKind.Local), null, null, "Bộ sưu tập người máy - biểu tượng của tương lai.", null, 0, "https://th.bing.com/th/id/OIG.D7FfBXsOQCjc28w68xZS?pid=ImgGn", "35966d1a-9b08-4743-b1c3-474a58350f6e_t.jpg", "Kỷ nguyên mới" },
                    { new Guid("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 18, 20, 55, 30, 456, DateTimeKind.Local), null, null, "Minh họa những cuộc chiến tiêu biểu của thời đại", null, 0, "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain", "3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3_t.jpg", "Vẻ đẹp của lịch sử" },
                    { new Guid("56f86f82-4622-4710-8d1c-b8c1664711a2"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 22, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại", null, 0, "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain", "56f86f82-4622-4710-8d1c-b8c1664711a2_t.jpg", "Dấu vết của quá khứ" },
                    { new Guid("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 26, 12, 40, 28, 901, DateTimeKind.Local), null, null, "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý", null, 0, "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn", "5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0_t.jpg", "Sự đồng hành của đối tác tâm lý" },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2023, 11, 6, 1, 20, 45, 890, DateTimeKind.Local), null, null, null, null, 0, "https://th.bing.com/th/id/OIG.MC3PObbEmuJhfsPJ8biQ?pid=ImgGn", "72fbdead-0704-4f69-82ec-0cd09218fef9_t.jpg", "Touhou Project Image Cute" },
                    { new Guid("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 11, 9, 37, 42, 345, DateTimeKind.Local), null, null, "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống", null, 0, "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn", "7a04e5c7-ffea-45da-80d2-875b0a0b8d35_t.jpg", "Hành trình tìm kiếm đam mê" },
                    { new Guid("8c24a1d8-9f14-44cd-9e86-2c542d14413c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 20, 7, 30, 15, 567, DateTimeKind.Local), null, null, "Minh họa cho hành trình không ngừng của sự sáng tạo", null, 0, "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn", "8c24a1d8-9f14-44cd-9e86-2c542d14413c_t.jpg", "Hành trình của sự sáng tạo" },
                    { new Guid("91f9a14d-66a9-43da-8e43-2579baf7c8a7"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 2, 4, 20, 10, 234, DateTimeKind.Local), null, null, "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai", null, 0, "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn", "91f9a14d-66a9-43da-8e43-2579baf7c8a7_t.jpg", "Sự lạc quan của tương lai" },
                    { new Guid("9202bb7f-71f3-4641-b1d4-9bc858416d84"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 10, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người", null, 0, "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain", "9202bb7f-71f3-4641-b1d4-9bc858416d84_t.jpg", "Vũ trụ tâm trí" },
                    { new Guid("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 5, 9, 37, 42, 345, DateTimeKind.Local), null, null, "Tuyển tập những bức vẽ về hoàng hôn", null, 0, "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain", "ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3_t.jpg", "Hoàng hôn rực nắng" },
                    { new Guid("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 8, 20, 55, 30, 456, DateTimeKind.Local), null, null, "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người", null, 0, "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn", "b1c16326-7a16-4f6b-a76d-cf15ce2c71d3_t.jpg", "Nơi gặp gỡ tâm hồn" },
                    { new Guid("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 20, 22, 20, 45, 890, DateTimeKind.Local), null, null, "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống", null, 0, "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn", "e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7_t.jpg", "Hành trình sâu cảm xúc" },
                    { new Guid("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 12, 17, 55, 30, 456, DateTimeKind.Local), null, null, "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng", null, 0, "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn", "f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4_t.jpg", "Biển cả của tri thức" },
                    { new Guid("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 30, 1, 30, 15, 567, DateTimeKind.Local), null, null, "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta", null, 0, "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn", "fb7c52b9-64f8-4e84-a992-14b8bcb6ea35_t.jpg", "Mặt trời bên trong" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "LastModificatedOn", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[] { new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "2 - 3 tuần", "Mô tả Dịch vụ thiết kế", null, new DateTime(2024, 1, 17, 15, 43, 9, 414, DateTimeKind.Local).AddTicks(981), 2, 2, "Dịch vụ thiết kế", 100000.0, "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png" });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "AccountId", "Balance", "WithdrawInformation", "WithdrawMethod" },
                values: new object[,]
                {
                    { new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0"), new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), 2000.0, "0902287461", 0 },
                    { new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), 1000.0, "0939959417", 0 },
                    { new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2"), new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), 1000.0, "0902287462", 0 },
                    { new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3"), new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), 1000.0, "0902287463", 0 },
                    { new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), 1000.0, "0902287464", 0 }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "ArtworkId", "AssetName", "AssetTitle", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "Location", "Order", "Price" },
                values: new object[,]
                {
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "PTS_1.zip", "Touhout PTS", null, null, "Tặng các bạn", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 0.0 },
                    { new Guid("8225058f-9f38-49f2-a68d-d9237b0a550f"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "PTS_1.zip", "Tàu hũ ZIP", null, null, null, null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 12.0 },
                    { new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "PTS_1.zip", "File PTS tuyển tập minh hoạ sách tâm lý", null, null, "Mua đê", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5") }
                });

            migrationBuilder.InsertData(
                table: "CategoryServiceDetail",
                columns: new[] { "CategoryId", "ServiceId" },
                values: new object[] { new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ArtworkId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "LastModificatedBy", "ReplyId" },
                values: new object[,]
                {
                    { new Guid("457f3324-5594-4526-ab24-25c63e5ee7bd"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "10 điểm", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("5075efb6-cd23-4cea-8882-2f5669c70ea7"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "Like", new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("74524095-a079-44b0-9e2a-a8e67ae6b06e"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "Minh hoạ xuất sắc", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("8ea03178-3cc7-40e5-9344-a6a96c492a42"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "Đây là một bức tranh rất đẹp", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("e05281fb-cfb2-4dc3-9be8-d8ae59016f9a"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "Cute and funny", new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("01aa2232-7628-4227-b034-1c1a32cad359"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i1.jpg", null, null, "https://www.dtv-ebook.com/images/files_2/2023/022023/tam-ly-hoc-toi-pham-phac-hoa-chan-dung-ke-pham-toi-diep-hong-vu.jpg", 0 },
                    { new Guid("36208d9b-471a-4a88-be28-adabfd1f2ae5"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "72fbdead-0704-4f69-82ec-0cd09218fef9_i0.jpg", null, null, "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p0.png", 0 },
                    { new Guid("5d96552b-ff92-4064-8858-5e1e96ee9899"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "72fbdead-0704-4f69-82ec-0cd09218fef9_i1.jpg", null, null, "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p1.png", 1 },
                    { new Guid("ae8fb7be-5c63-481e-b997-2ada5ac5392b"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i2.jpg", null, null, "https://lh3.googleusercontent.com/QKQqZt0RivsBmyjwFI8EomO6YZ2-hnSsiwLdKG9btAiNhVjiwpKtzTiULFqTRCo5JUOe5t8f6Be_sZ9ZBYRD7v3EYwqzlkomHabN_LqntP61rVbqqk9wuQqgVY4Dmk7JseAHmjbNWRacbMJynaBXgCoYvcQzAuYPOgNj-P2CAEWroKZcieC2GDyal2x02Cw0izhqYNCnJAQLnEPSErSXgYNBoSb3KlmjHcev9zq2KXRaorp04_aKLN5-iewZ27ee9OWmSuwfvnGgjSK98rKdtGfnqw5U_1cp1R89brso1E8VCIhFGfRTKijJMdCtjE3VbpyO_3vI46D5UVbJZB3N-c0-DulKgbP1EFp5p_wbgBwL2AQVAgQCB2TJ1IS_hVKqVS1GZ3xsCleYb7xTkaqqcojQIbR1GYMxirT_u2jU6xHq6ycB2w6UPCo_DZJfVhieyZXzjpIa92pN-6UM4I-Ou54BnFpvANrOxfOWxblViYR43PrSdHgu5XGGQYg2SYKvuAqbzkpOLpcnyRQBxDPV6bCMURXDTvnmRQj1Rl_14MEW278wjOe-D39mATYeEO6Xfq445Wu9SUEcXd40soLtSNcun92XJ-j_0Dyr1Dd2argkutkMXgiqRHyZxN1hfadB_T1xQ3Ln9TA8oSRrYEmoUIXi4iS9XD08kj5FZf-slMLA_KQeYT7F2Alkx11IBq2aahNUlf1FTWykZVpyxAr0DNjCypS44Lbmqsdw7xfQzKT8WrLR=w400-h500-no", 1 },
                    { new Guid("ff16271c-c04a-4cec-b6f1-04b555659b5a"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i3.jpg", null, null, "https://vietbooks.info/attachments/upload_2023-2-3_11-29-1-png.19599/", 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6") }
                });

            migrationBuilder.InsertData(
                table: "WalletHistory",
                columns: new[] { "Id", "Amount", "CreatedBy", "CreatedOn", "PaymentMethod", "TransactionStatus", "Type", "WalletId" },
                values: new object[,]
                {
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0290"), 200.0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 7, 15, 30, 3, 678, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0291"), 2500.0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 10, 21, 20, 10, 234, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0292"), 2000.0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 11, 14, 2, 59, 59, 0, DateTimeKind.Local), 0, 0, 0, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0293"), 300.0, new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2023, 12, 10, 12, 40, 28, 901, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0294"), 200.0, new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2023, 11, 16, 9, 37, 42, 345, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0295"), 2500.0, new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2023, 11, 29, 1, 30, 15, 567, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0296"), 1700.0, new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2023, 12, 1, 6, 59, 59, 999, DateTimeKind.Local), 0, 0, 0, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0297"), 200.0, new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2023, 11, 19, 12, 40, 28, 901, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0298"), 2500.0, new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2023, 11, 29, 1, 30, 15, 567, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0299"), 1700.0, new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2023, 12, 10, 12, 40, 28, 901, DateTimeKind.Local), 0, 0, 0, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029a"), 200.0, new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2023, 11, 22, 12, 37, 42, 345, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029b"), 2500.0, new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2023, 11, 15, 10, 45, 20, 123, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029c"), 1700.0, new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2023, 12, 5, 9, 37, 42, 345, DateTimeKind.Local), 0, 0, 0, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029d"), 3000.0, new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), new DateTime(2023, 11, 3, 17, 45, 20, 123, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029e"), 1500.0, new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), new DateTime(2023, 11, 17, 9, 59, 59, 0, DateTimeKind.Local), 0, 0, 0, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0") },
                    { new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029f"), 500.0, new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), new DateTime(2023, 11, 6, 1, 20, 45, 890, DateTimeKind.Local), 0, 0, 1, new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0") }
                });

            migrationBuilder.InsertData(
                table: "TransactionHistory",
                columns: new[] { "Id", "AssetId", "CreatedBy", "CreatedOn", "Detail", "Price", "ProposalId", "TransactionStatus" },
                values: new object[,]
                {
                    { new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d1"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), new DateTime(2024, 1, 13, 22, 30, 3, 678, DateTimeKind.Local), "Mở khóa tài nguyên \"Tàu hũ ZIP\"", 12.0, null, 1 },
                    { new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d2"), new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"), new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), new DateTime(2024, 1, 15, 9, 59, 59, 0, DateTimeKind.Local), "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"", 10.0, null, 1 },
                    { new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d3"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 14, 22, 30, 3, 678, DateTimeKind.Local), "Mở khóa tài nguyên \"Tàu hũ ZIP\"", 12.0, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-5141-08dc1445b3e3"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-e5f6-08dc1445b3e2"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("35966d1a-9b08-4743-b1c3-474a58350f5e"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("56f86f82-4622-4710-8d1c-b8c1664711a2"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("8c24a1d8-9f14-44cd-9e86-2c542d14413c"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("91f9a14d-66a9-43da-8e43-2579baf7c8a7"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("9202bb7f-71f3-4641-b1d4-9bc858416d84"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"));

            migrationBuilder.DeleteData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("8225058f-9f38-49f2-a68d-d9237b0a550f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("490f5bd6-1a32-4e9b-9236-5794c97526e1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("6dfe4e90-98e1-43e5-b2c1-ef7fd9e6fb67"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a6d7e9b2-85af-4f01-bd97-2c3bbd3a7e09"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c51283f7-6d58-4a70-9bf2-13d3b5bc8456"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e839e134-9158-4d2d-a04f-503fdd2d2751"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e839e134-9158-4d2d-a04f-503fdd2d275e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f4e81ac1-1a6e-47c3-92fc-7a54ae95d689"));

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a") });

            migrationBuilder.DeleteData(
                table: "CategoryArtworkDetail",
                keyColumns: new[] { "ArtworkId", "CategoryId" },
                keyValues: new object[] { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5") });

            migrationBuilder.DeleteData(
                table: "CategoryServiceDetail",
                keyColumns: new[] { "CategoryId", "ServiceId" },
                keyValues: new object[] { new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("457f3324-5594-4526-ab24-25c63e5ee7bd"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("5075efb6-cd23-4cea-8882-2f5669c70ea7"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("74524095-a079-44b0-9e2a-a8e67ae6b06e"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("8ea03178-3cc7-40e5-9344-a6a96c492a42"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("e05281fb-cfb2-4dc3-9be8-d8ae59016f9a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("01aa2232-7628-4227-b034-1c1a32cad359"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("36208d9b-471a-4a88-be28-adabfd1f2ae5"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5d96552b-ff92-4064-8858-5e1e96ee9899"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ae8fb7be-5c63-481e-b997-2ada5ac5392b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ff16271c-c04a-4cec-b6f1-04b555659b5a"));

            migrationBuilder.DeleteData(
                table: "ServiceDetail",
                keyColumns: new[] { "ArtworkId", "ServiceId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec1"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec3"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec4"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec6"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec7"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95eca"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecc"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecd"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ece"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecf"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed0"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed1"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed2"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed3"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed4"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed5"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed7"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed8"));

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb") });

            migrationBuilder.DeleteData(
                table: "TagDetail",
                keyColumns: new[] { "ArtworkId", "TagId" },
                keyValues: new object[] { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6") });

            migrationBuilder.DeleteData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d1"));

            migrationBuilder.DeleteData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d2"));

            migrationBuilder.DeleteData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5951c1f-b46f-4af1-9c9a-f95dc6e9f9d3"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0290"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0291"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0292"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0293"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0294"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0295"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0296"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0297"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0298"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf0299"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029a"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029b"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029c"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029d"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029e"));

            migrationBuilder.DeleteData(
                table: "WalletHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b7d2223-c1fe-4a45-ad69-8e893ebf029f"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"));

            migrationBuilder.DeleteData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"));

            migrationBuilder.DeleteData(
                table: "Asset",
                keyColumn: "Id",
                keyValue: new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c0"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c1"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c2"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c3"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("73b5f912-28d7-4473-9c8d-56a734d8a1c4"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"));

            migrationBuilder.DeleteData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"));
        }
    }
}
