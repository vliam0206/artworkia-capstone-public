using Domain.Entitites;
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
    }
}
