using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable(nameof(Collection));

            builder.Property(x => x.Id).HasDefaultValueSql("newid()");

            // relationship
            builder.HasOne(x => x.Account).WithMany(p => p.Collections).HasForeignKey(x => x.CreatedBy);
            builder.HasMany(x => x.Bookmarks).WithOne(b => b.Collection).HasForeignKey(b => b.CollectionId);
        }
    }
}
