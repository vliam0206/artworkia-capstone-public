using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
{
    public void Configure(EntityTypeBuilder<Artwork> builder)
    {
        builder.ToTable(nameof(Artwork));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Account).WithMany(a => a.Artworks).HasForeignKey(x => x.CreatedBy);
        builder.HasMany(x => x.CategoryArtworkDetails).WithOne(d => d.Artwork).HasForeignKey(d => d.ArtworkId);
        builder.HasMany(x => x.Assets).WithOne(a => a.Artwork).HasForeignKey(a => a.ArtworkId);
        builder.HasMany(x => x.Images).WithOne(a => a.Artwork).HasForeignKey(a => a.ArtworkId);
        builder.HasMany(x => x.TagDetails).WithOne(d => d.Artwork).HasForeignKey(d => d.ArtworkId);
        builder.HasMany(x => x.Likes).WithOne(l => l.Artwork).HasForeignKey(l => l.ArtworkId);
        builder.HasMany(x => x.Comments).WithOne(c => c.Artwork).HasForeignKey(c => c.ArtworkId);
        builder.HasMany(x => x.ServiceDetails).WithOne(c => c.Artwork).HasForeignKey(c => c.ArtworkId);

        #region init data 
        // Seed 50 artworks
        builder.HasData
        (
            // Artwork 1
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Title = "Hoàng hôn rực nắng",
                Description = "Tuyển tập những bức vẽ về hoàng hôn",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-02T02:37:42.345Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "00000000-0000-0000-0000-000000000001_t.jpg",
                ViewCount = 1344,
                LikeCount = 8,
                CommentCount = 6,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 2
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Title = "Hành trình sâu cảm xúc",
                Description = "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-03T15:20:45.890Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000001_t.jpg",
                ViewCount = 327,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 3
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Title = "Chiến thắng Điện Biên Phủ",
                Description = "Minh họa cuộc chiến tiêu biểu của thời đại",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), //hoanganh
                CreatedOn = DateTime.Parse("2023-11-04T13:55:30.456Z"),
                Thumbnail = "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000002_t.jpg",
                ViewCount = 2138,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 4
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Title = "Dấu vết của quá khứ",
                Description = "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-05T08:30:03.678Z"),
                Thumbnail = "https://bizweb.dktcdn.net/100/378/894/files/5.jpg?v=1627978886825",
                ThumbnailName = "00000000-0000-0000-0000-000000000004_t.jpg",
                ViewCount = 203,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 5
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Title = "Hành trình của sự sáng tạo",
                Description = "Minh họa cho hành trình không ngừng của sự sáng tạo",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), //thong
                CreatedOn = DateTime.Parse("2023-11-06T00:30:15.567Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000005_t.jpg",
                ViewCount = 779,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 6
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Title = "Sự đồng hành của đối tác tâm lý",
                Description = "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-07T05:40:28.901Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000006_t.jpg",
                ViewCount = 245,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 7
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Title = "Mặt trời bên trong",
                Description = "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-08T18:30:15.567Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000007_t.jpg",
                ViewCount = 356,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 8
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Title = "Tuyển tập minh hoạ sách tâm lý",
                Description = "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-01T08:30:03.678Z"),
                Thumbnail = "https://static-company.waka.vn/img.media/tin%20t%E1%BB%A9c/38540.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000008_t.jpg",
                ViewCount = 342,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 9
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Title = "Sự lạc quan của tương lai",
                Description = "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phuhuynh
                CreatedOn = DateTime.Parse("2023-11-09T21:20:10.234Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000009_t.jpg",
                ViewCount = 826,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 10
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                Title = "Nơi gặp gỡ tâm hồn",
                Description = "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-10T13:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000a_t.jpg",
                ViewCount = 145,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 11
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                Title = "Vũ trụ tâm trí",
                Description = "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phuhuynh
                CreatedOn = DateTime.Parse("2023-11-11T08:30:03.678Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "00000000-0000-0000-0000-00000000000b_t.jpg",
                ViewCount = 565,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 12
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                Title = "Cáo già",
                Description = "Anh như con cáo Em như cành nho xanh Khi em còn trẻ và đẹp em lại ko dành cho anhhhhh.",
                Privacy = PrivacyEnum.Private,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-11T02:37:42.345Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000c_t.jpg",
                ViewCount = 234,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 13
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                Title = "Làng quê",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000015"), //vuthao
                CreatedOn = DateTime.Parse("2023-11-11T02:37:42.345Z"),
                Thumbnail = "https://i.pinimg.com/originals/7f/b2/ab/7fb2abc0dddd2aa40a86ce6c318b369a.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000000d_t.jpg",
                ViewCount = 234,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 14
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Title = "Kỷ nguyên mới",
                Description = "Bộ sưu tập người máy - biểu tượng của tương lai.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-13T08:40:28.901Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.D7FfBXsOQCjc28w68xZS?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000e_t.jpg",
                ViewCount = 1234,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 15
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Title = "Tuyển tập ảnh cánh cụt cute",
                Description = "Cánh cụt cute",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phu
                CreatedOn = DateTime.Parse("2023-11-14T08:20:45.890Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.MC3PObbEmuJhfsPJ8biQ?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000f_t.jpg",
                ViewCount = 0,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Waiting,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 16
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Title = "Biển cả của tri thức",
                Description = "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-14T10:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-000000000010_t.jpg",
                ViewCount = 344,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Waiting,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 17
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Title = "Bất Động Sản Thạnh Lộc-Thạnh Xuân",
                Description = "Bán đất ngay ngã tư ga, Hà Huy Giáp vào 1/sẹc, phường Thạnh Xuân,quận 12.\r\n" +
                "-  Khu phân lô đại phú, gần Bánh Mỳ Hà Nội.\r\n" +
                "- Diện tích: 4,10m x 14m\r\n" +
                "- Hướng Tây nam\r\n" +
                "- Giá: 3,5 tỷ còn thương lượng \r\n" +
                "- Đường nhựa xe tải vào tận nơi .\r\n" +
                "-Liên hệ: 0347307890 Nguyễn Hoàng.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000008"), //nguyenhoang
                CreatedOn = DateTime.Parse("2023-11-10T08:30:03.678Z"),
                Thumbnail = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FThumbnail%2F00000000-0000-0000-0000-000000000011_t.jpg?alt=media&token=aad2c767-acdf-470f-bc35-9c55947cc9af",
                ThumbnailName = "00000000-0000-0000-0000-000000000011_t.jpg",
                ViewCount = 70,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 18
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Title = "Countdown / character introduction images for a game release",
                Description = "The first ever licensed visual novel in Vietnam, which might not " +
                "sound special, is a huge milestone in the development of this extremely niche " +
                "genre in my community. Great stuffs, and it was an honor of mine to work with this.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phu
                CreatedOn = DateTime.Parse("2023-11-12T09:30:03.678Z"),
                Thumbnail = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc",
                ThumbnailName = "00000000-0000-0000-0000-000000000012_t.jpg",
                ViewCount = 1011,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 19
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Title = "Tranh sơn dầu Đại tướng Võ Nguyên Giáp",
                Description = "Là một họa sĩ được sinh ra và lớn lên khi đất nước đã thống nhất, Mai Duy Minh " +
                "đã cố gắng hết sức có thể trong việc tìm kiếm một câu trả lời cho riêng cá nhân anh về cách mà " +
                "các thế hệ người Việt Nam bền bỉ đi qua mọi gian khổ để bảo vệ độc lập dân tộc. Tất cả những nỗ " +
                "lực tìm kiếm và lắng nghe mọi vang vọng từ quá khứ chiến đấu anh dũng ấy của cha anh đi trước đã " +
                "được hội tụ trong bức tranh “Điện Biên Phủ”..",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                CreatedOn = DateTime.Parse("2023-11-13T11:11:03.678Z"),
                Thumbnail = "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000013_t.jpg",
                ViewCount = 3045,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                IsAIGenerated = false
            },

            // Artwork 20
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Title = "Không gian vũ trụ",
                Description = "A collection of 173 wallpapers in 4K resolution from THE SIGHTS OF SPACE",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-00000000000b"), //melodysheep
                CreatedOn = DateTime.Parse("2023-11-13T17:11:03.678Z"),
                Thumbnail = "https://f4.bcbits.com/img/a0127149981_16.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000014_t.jpg",
                ViewCount = 725,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },

            // Artwork 21
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                Title = "Tương lai loài người",
                Description = "Save the date.  THE HUMAN FUTURE drops on August 15.  Casting my stone in the opposite direction " +
                "of all the pessimists out there.  see you soon :)",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-00000000000b"), //melodysheep
                CreatedOn = DateTime.Parse("2023-11-14T14:11:03.678Z"),
                Thumbnail = "https://yt3.ggpht.com/7CFh0HeCsVSD9UfK1LSc9imflCpKDZT41gNjj_qehvRKt0J9fgmjw2tYjf4oMpbsn0BagczFhx_TTQ=s1600-rw-nd-v1",
                ThumbnailName = "00000000-0000-0000-0000-000000000015_t.jpg",
                ViewCount = 435,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 22
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Title = "THE OUTPOST",
                Description = "How might we discover intelligent life?\r\n\r\nInstead of waiting for radio " +
                "signals or scanning alien atmospheres, we could look to distant asteroid fields for evidence.  " +
                "Advanced civilizations would have numerous reasons to probe asteroids for materials. " +
                "They are rich in resources and easier to manipulate because of their lower gravity.\r\n\r\n" +
                "Spotting chemical anomalies or infrared waste heat around distant asteroid fields could lead us to the ultimate discovery.\r\n\r\n" +
                "Presenting THE OUTPOST: a digital art piece from Life Beyond 3",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-00000000000b"), //melodysheep
                CreatedOn = DateTime.Parse("2023-11-20T08:20:45.890Z"),
                Thumbnail = "https://yt3.ggpht.com/gD2jfNal37ZYf6zkA7CX8CdBQ3WJDP9wFxA-JgrTl0RMGmWh7QcaWG1L2dzBWHUV_qd20ddxXJSMi90=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1",
                ThumbnailName = "00000000-0000-0000-0000-000000000016_t.jpg",
                ViewCount = 564,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 23
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                Title = "Mọt sách",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000010"), //buiduong
                CreatedOn = DateTime.Parse("2023-11-21T08:30:03.678Z"),
                Thumbnail = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F106127234_p0.jpg?alt=media&token=86c5c12c-bee7-4a57-8db1-402e317d5c23",
                ThumbnailName = "00000000-0000-0000-0000-000000000017_t.jpg",
                ViewCount = 725,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },

            // Artwork 24
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                Title = "Cô Gái Đeo Bông Tai Ngọc Trai",
                Description = "Bức tranh hấp dẫn này thường được so sánh với \"Mona Lisa\". " +
                "Bên cạnh sự khác biệt về phong cách, về mặt kỹ thuật \"Girl With a Pearl Earring\" " +
                "thậm chí không phải là một bức chân dung, mà là một \"tronie\" - một từ tiếng Hà Lan để " +
                "chỉ bức tranh của một nhân vật tưởng tượng với các đặc điểm phóng đại.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phu
                CreatedOn = DateTime.Parse("2023-11-22T08:20:45.890Z"),
                Thumbnail = "https://www.kiettacnghethuat.com/wp-content/uploads/Girl-With-a-Pearl-Earring.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000018_t.jpg",
                ViewCount = 124,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 25
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                Title = "Đêm đầy sao",
                Description = "Bức tranh \"The Starry Night\" của Vincent van Gogh là một trong những bức tranh nổi tiếng nhất của ông. " +
                "Bức tranh này được vẽ vào năm 1889 và hiện đang được trưng bày tại Bảo tàng Nghệ thuật Modern ở New York.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), //thong
                CreatedOn = DateTime.Parse("2023-11-23T08:20:45.890Z"),
                Thumbnail = "https://www.kiettacnghethuat.com/wp-content/uploads/The-Starry-Night.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000019_t.jpg",
                ViewCount = 462,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 26
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                Title = "Thiếu nữ bên hoa huệ",
                Description = "Thiếu nữ bên hoa huệ là một tác phẩm tranh sơn dầu do họa sĩ Tô Ngọc Vân sáng tác năm 1943." +
                " Bức tranh mô tả chân dung một thiếu nữ mặc áo dài trắng bên cạnh lọ hoa huệ trắng.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"), //thong
                CreatedOn = DateTime.Parse("2023-11-24T08:20:45.890Z"),
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg/800px-To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001a_t.jpg",
                ViewCount = 874,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 27
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                Title = "꒰𝙰𝚒 𝙰𝚛𝚝꒱ Wallpaper",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000011"), //phamha
                CreatedOn = DateTime.Parse("2023-11-25T08:20:45.890Z"),
                Thumbnail = "https://i.pinimg.com/originals/5b/43/fc/5b43fc89abad25aa3359bfe0f27923f9.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001b_t.jpg",
                ViewCount = 124,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 28
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                Title = "Nhà hát Opera Vienna",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000017"), //vudang
                CreatedOn = DateTime.Parse("2023-11-26T08:20:45.890Z"),
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Adolf_Hitler_-_Wien_Oper.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001c_t.jpg",
                ViewCount = 666,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 29
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                Title = "Hofbräuhaus, Munich",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000017"), //vudang
                CreatedOn = DateTime.Parse("2023-11-27T08:20:45.890Z"),
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/9/93/Adolf_Hitler_-_Hofbr%C3%A4uhaus.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001d_t.jpg",
                ViewCount = 144,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 30
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                Title = "Lâu đài Old Town ở Munich",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000017"), //vudang
                CreatedOn = DateTime.Parse("2023-11-28T08:20:45.890Z"),
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg/1024px-Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001e_t.jpg",
                ViewCount = 452,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 31
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                Title = "Khoảng sân trong ở phủ thống sứ cũ tại Munich",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000017"), //vudang
                CreatedOn = DateTime.Parse("2023-11-29T08:20:45.890Z"),
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Adolf_Hitler_Der_Alte_Hof.jpg/1024px-Adolf_Hitler_Der_Alte_Hof.jpg",
                ThumbnailName = "00000000-0000-0000-0000-00000000001f_t.jpg",
                ViewCount = 124,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 32
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                Title = "Phục chế ảnh liệt sĩ",
                Description = "Hầu hết các bức ảnh đều chụp cách đây mấy chục năm, nước ảnh ố mờ, bay màu. " +
                "Có nhiều bức ảnh được vẽ lại theo trí nhớ người thân nên để phục chế lại phải mất nhiều thời gian, " +
                "phải cẩn thận chỉnh sửa từng chi tiết",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), //hoanganh
                CreatedOn = DateTime.Parse("2023-11-29T08:20:45.890Z"),
                Thumbnail = "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png",
                ThumbnailName = "00000000-0000-0000-0000-000000000020_t.jpg",
                ViewCount = 968,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            }
        );
        #endregion
    }
}
