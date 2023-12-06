using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class CategoryServiceDetailConfiguration : IEntityTypeConfiguration<CategoryServiceDetail>
{
    public void Configure(EntityTypeBuilder<CategoryServiceDetail> builder)
    {
        builder.ToTable(nameof(CategoryServiceDetail));
        builder.HasKey(x => new { x.CategoryId, x.ServiceId });

        // relationship
        builder.HasOne(x => x.Category).WithMany(c => c.CategoryServiceDetails).HasForeignKey(x => x.CategoryId);
        builder.HasOne(x => x.Service).WithMany(s => s.CategoryServiceDetails).HasForeignKey(x => x.ServiceId);
    }
}
