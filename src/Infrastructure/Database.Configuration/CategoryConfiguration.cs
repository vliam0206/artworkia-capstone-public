using Application.Commons;
using Domain.Entitites;
using Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");

        // relationship
        builder.HasOne(x => x.Parent).WithMany(p => p.Children).HasForeignKey(x => x.ParentCategory);
        builder.HasMany(x => x.CategoryServiceDetails).WithOne(d => d.Category).HasForeignKey(d => d.CategoryId);
        builder.HasMany(x => x.CategoryArtworkDetails).WithOne(d => d.Category).HasForeignKey(d => d.CategoryId);

        #region init data
        builder.HasData
        (
            new Category() { Id = Guid.Parse("57dbdb36-f9ad-4926-9fb6-2df15969ed5e"), CategoryName = "Minh hoạ", ParentCategory = null },
            new Category() { Id = Guid.Parse("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), CategoryName = "Thiết kế đồ họa", ParentCategory = null },
            new Category() { Id = Guid.Parse("c51283f7-6d58-4a70-9bf2-13d3b5bc8456"), CategoryName = "UI/UX", ParentCategory = null },
            new Category() { Id = Guid.Parse("a6d7e9b2-85af-4f01-bd97-2c3bbd3a7e09"), CategoryName = "Kiến trúc", ParentCategory = null },
            new Category() { Id = Guid.Parse("f4e81ac1-1a6e-47c3-92fc-7a54ae95d689"), CategoryName = "Thời trang", ParentCategory = null },
            new Category() { Id = Guid.Parse("6dfe4e90-98e1-43e5-b2c1-ef7fd9e6fb67"), CategoryName = "Đồ họa chuyển động", ParentCategory = null },
            new Category() { Id = Guid.Parse("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3"), CategoryName = "In ấn", ParentCategory = null },
            new Category() { Id = Guid.Parse("490f5bd6-1a32-4e9b-9236-5794c97526e1"), CategoryName = "Đồ họa 3D", ParentCategory = null },
            new Category() { Id = Guid.Parse("ced1a254-ecac-47e4-ae18-5d23c2711bf5"), CategoryName = "Nghệ thuật số", ParentCategory = null },
            new Category() { Id = Guid.Parse("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), CategoryName = "Nhiếp ảnh", ParentCategory = null },
            new Category() { Id = Guid.Parse("e839e134-9158-4d2d-a04f-503fdd2d275e"), CategoryName = "Thiết kế sản phẩm", ParentCategory = null },
            new Category() { Id = Guid.Parse("e839e134-9158-4d2d-a04f-503fdd2d2751"), CategoryName = "Quảng cáo", ParentCategory = null }
        );
        #endregion
    }
}
