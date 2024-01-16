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


        #region init data
        builder.HasData
        (
            new CategoryServiceDetail()
            {
                CategoryId = Guid.Parse("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"),
                ServiceId = Guid.Parse("1c8542d4-41bd-492b-9d21-905c6a8b0532")
            }
        );
        #endregion
    }
}
