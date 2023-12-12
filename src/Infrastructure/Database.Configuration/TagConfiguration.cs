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

        // relationship
        builder.HasMany(x => x.TagDetails).WithOne(d => d.Tag).HasForeignKey(d => d.TagId);
    }
}
