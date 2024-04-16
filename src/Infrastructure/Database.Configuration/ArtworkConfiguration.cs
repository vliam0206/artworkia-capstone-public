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
                ViewCount = 344,
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
                ViewCount = 638,
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
                Thumbnail = "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "00000000-0000-0000-0000-000000000004_t.jpg",
                ViewCount = 203,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                Thumbnail = "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "00000000-0000-0000-0000-000000000008_t.jpg",
                ViewCount = 342,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 10
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                Title = "Nơi gặp gỡ tâm hồn",
                Description = "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), //hoanganh
                CreatedOn = DateTime.Parse("2023-11-10T13:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000a_t.jpg",
                ViewCount = 145,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 12
            new Artwork()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                Title = "Hành trình tìm kiếm đam mê",
                Description = "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống",
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
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Title = "Kỷ nguyên mới",
                Description = "Bộ sưu tập người máy - biểu tượng của tương lai.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-13T08:40:28.901Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.D7FfBXsOQCjc28w68xZS?pid=ImgGn",
                ThumbnailName = "00000000-0000-0000-0000-00000000000e_t.jpg",
                ViewCount = 123,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = true
            },

            // Artwork 14
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
                ViewCount = 564,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Waiting,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IsAIGenerated = false
            },

            // Artwork 15
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 16
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
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 17
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
                ThumbnailName = "00000000-0000-0000-0000-000000000011_t.jpg",
                ViewCount = 1011,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },

            // Artwork 18
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
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000011"), //phamha
                CreatedOn = DateTime.Parse("2023-11-13T11:11:03.678Z"),
                Thumbnail = "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg",
                ThumbnailName = "00000000-0000-0000-0000-000000000012_t.jpg",
                ViewCount = 345,
                LikeCount = 0,
                CommentCount = 0,
                State = StateEnum.Accepted,
                LicenseTypeId = Guid.Parse("00000000-0000-0000-0000-000000000008")
            }


        );
        #endregion
    }
}
