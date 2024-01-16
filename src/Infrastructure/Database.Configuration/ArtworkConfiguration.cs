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
                Title = "Tuyển tập minh hoạ sách tâm lý",
                Description = "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha",
                Privacy = 0,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-1-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "35966d1a-9b08-4743-b1c3-474a58350f6e_t.jpg",
            },
            new Artwork()
            {
                Id = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                Title = "Touhou Project Image Cute",
                Description = null,
                Privacy = 0,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), //phu
                CreatedOn = DateTime.Parse("2024-1-2"),
                Thumbnail = "https://i.pximg.net/c/250x250_80_a2/custom-thumb/img/2023/11/13/18/56/54/113380427_p0_custom1200.jpg",
                ThumbnailName = "72fbdead-0704-4f69-82ec-0cd09218fef9_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f5e"),
                Title = "Tuyển tập minh hoạ sách tâm lý",
                Description = "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha",
                Privacy = 0,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-1-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "35966d1a-9b08-4743-b1c3-474a58350f5e_t.jpg",
            },
            new Artwork()
            {
                Id = Guid.Parse("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"),
                Title = "Bí mật tâm lý học",
                Description = "Sách tìm hiểu về những bí mật đằng sau tâm lý con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-2-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"),
                Title = "Hành trình sâu cảm xúc",
                Description = "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-2-15"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"),
                Title = "Sự huyền bí của tâm trí",
                Description = "Bức tranh thể hiện sự huyền bí và phức tạp của tâm trí con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-3-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("56f86f82-4622-4710-8d1c-b8c1664711a2"),
                Title = "Dấu vết của quá khứ",
                Description = "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-4-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "56f86f82-4622-4710-8d1c-b8c1664711a2_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("8c24a1d8-9f14-44cd-9e86-2c542d14413c"),
                Title = "Hành trình của sự sáng tạo",
                Description = "Minh họa cho hành trình không ngừng của sự sáng tạo",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-5-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "8c24a1d8-9f14-44cd-9e86-2c542d14413c_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"),
                Title = "Sự đồng hành của đối tác tâm lý",
                Description = "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-6-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"),
                Title = "Mặt trời bên trong",
                Description = "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-7-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "fb7c52b9-64f8-4e84-a992-14b8bcb6ea35_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("91f9a14d-66a9-43da-8e43-2579baf7c8a7"),
                Title = "Sự lạc quan của tương lai",
                Description = "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-8-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "91f9a14d-66a9-43da-8e43-2579baf7c8a7_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"),
                Title = "Nơi gặp gỡ tâm hồn",
                Description = "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-9-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "b1c16326-7a16-4f6b-a76d-cf15ce2c71d3_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("9202bb7f-71f3-4641-b1d4-9bc858416d84"),
                Title = "Vũ trụ tâm trí",
                Description = "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-10-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "9202bb7f-71f3-4641-b1d4-9bc858416d84_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"),
                Title = "Hành trình tìm kiếm đam mê",
                Description = "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2024-12-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "7a04e5c7-ffea-45da-80d2-875b0a0b8d35_t.jpg",
            },

            new Artwork()
            {
                Id = Guid.Parse("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"),
                Title = "Biển cả của tri thức",
                Description = "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng",
                Privacy = PrivacyEnum.Public,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                CreatedOn = DateTime.Parse("2025-1-1"),
                Thumbnail = "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg",
                ThumbnailName = "f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4_t.jpg",
            }
        );
        #endregion
    }
}
