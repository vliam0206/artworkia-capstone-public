using AutoMapper.Execution;
using Domain.Entitites;
using Domain.Enums;
using Firebase.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

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
        builder.HasData
        (
            new Artwork()
            {
                Id = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                Title = "Kỷ nguyên mới",
                Description = "Bộ sưu tập người máy - biểu tượng của tương lai.",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-27T08:40:28.901Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.D7FfBXsOQCjc28w68xZS?pid=ImgGn",
                ThumbnailName = "35966d1a-9b08-4743-b1c3-474a58350f6e_t.jpg",
                ViewCount = 99,
                LikeCount = 2,
                CommentCount = 2
            },
            new Artwork()
            {
                Id = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                Title = "Touhou Project Image Cute",
                Description = null,
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), //phu
                CreatedOn = DateTime.Parse("2023-11-05T18:20:45.890Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.MC3PObbEmuJhfsPJ8biQ?pid=ImgGn",
                ThumbnailName = "72fbdead-0704-4f69-82ec-0cd09218fef9_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Waiting
            },
            new Artwork()
            {
                Id = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f5e"),
                Title = "Tuyển tập minh hoạ sách tâm lý",
                Description = "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-11-20T08:30:03.678Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "35966d1a-9b08-4743-b1c3-474a58350f5e_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"),
                Title = "Hoàng hôn rực nắng",
                Description = "Tuyển tập những bức vẽ về hoàng hôn",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-05T02:37:42.345Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"),
                Title = "Hành trình sâu cảm xúc",
                Description = "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-20T15:20:45.890Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn",
                ThumbnailName = "e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"),
                Title = "Vẻ đẹp của lịch sử",
                Description = "Minh họa những cuộc chiến tiêu biểu của thời đại",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-18T13:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("56f86f82-4622-4710-8d1c-b8c1664711a2"),
                Title = "Dấu vết của quá khứ",
                Description = "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-22T08:30:03.678Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "56f86f82-4622-4710-8d1c-b8c1664711a2_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("8c24a1d8-9f14-44cd-9e86-2c542d14413c"),
                Title = "Hành trình của sự sáng tạo",
                Description = "Minh họa cho hành trình không ngừng của sự sáng tạo",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-20T00:30:15.567Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn",
                ThumbnailName = "8c24a1d8-9f14-44cd-9e86-2c542d14413c_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"),
                Title = "Sự đồng hành của đối tác tâm lý",
                Description = "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-26T05:40:28.901Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn",
                ThumbnailName = "5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"),
                Title = "Mặt trời bên trong",
                Description = "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2023-12-29T18:30:15.567Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn",
                ThumbnailName = "fb7c52b9-64f8-4e84-a992-14b8bcb6ea35_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("91f9a14d-66a9-43da-8e43-2579baf7c8a7"),
                Title = "Sự lạc quan của tương lai",
                Description = "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-01-01T21:20:10.234Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn",
                ThumbnailName = "91f9a14d-66a9-43da-8e43-2579baf7c8a7_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"),
                Title = "Nơi gặp gỡ tâm hồn",
                Description = "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-01-08T13:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn",
                ThumbnailName = "b1c16326-7a16-4f6b-a76d-cf15ce2c71d3_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("9202bb7f-71f3-4641-b1d4-9bc858416d84"),
                Title = "Vũ trụ tâm trí",
                Description = "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-01-10T08:30:03.678Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ThumbnailName = "9202bb7f-71f3-4641-b1d4-9bc858416d84_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"),
                Title = "Hành trình tìm kiếm đam mê",
                Description = "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-01-11T02:37:42.345Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn",
                ThumbnailName = "7a04e5c7-ffea-45da-80d2-875b0a0b8d35_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            },
            new Artwork()
            {
                Id = Guid.Parse("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"),
                Title = "Biển cả của tri thức",
                Description = "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-01-12T10:55:30.456Z"),
                Thumbnail = "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn",
                ThumbnailName = "f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4_t.jpg",
                ViewCount = 99,
                LikeCount = 0,
                CommentCount = 0,
                Status = StateEnum.Accepted
            }
        );
        #endregion
    }
}
