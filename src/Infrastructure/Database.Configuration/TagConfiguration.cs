using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable(nameof(Tag));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(x => x.TagName).IsUnique();

        // relationship
        builder.HasMany(x => x.TagDetails).WithOne(d => d.Tag).HasForeignKey(d => d.TagId);


        #region init data
        builder.HasData
        (
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec1"), TagName = "Màu sắc" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2"), TagName = "Trừu tượng" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec3"), TagName = "Phong cảnh" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec4"), TagName = "Thiên nhiên" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), TagName = "Hình học" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec6"), TagName = "Anime" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec7"), TagName = "Chân dung" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8"), TagName = "Sáng tạo" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9"), TagName = "Kỹ thuật số" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95eca"), TagName = "Graffiti" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb"), TagName = "Dự án cá nhân" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecc"), TagName = "Nghệ thuật số hóa" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecd"), TagName = "Thể thao" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ece"), TagName = "Chủ đề xã hội" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecf"), TagName = "Vintage" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed0"), TagName = "Ảo" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed1"), TagName = "Minimalism" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed2"), TagName = "Figma" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed3"), TagName = "Mèo" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed4"), TagName = "Động vật hoang dã" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed5"), TagName = "Nền tảng" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6"), TagName = "Nghệ thuật đương đại" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed7"), TagName = "Chủ đề khoa học" },
            new Tag() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed8"), TagName = "Giao thông" }
        );
        #endregion
    }
}
