using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable(nameof(Bookmark));

            //composite key
            builder.HasKey(x => new { x.ArtworkId, x.CollectionId });

            // relationship
            builder.HasOne(x => x.Artwork).WithMany(a => a.Bookmarks).HasForeignKey(x => x.ArtworkId);
            builder.HasOne(x => x.Collection).WithMany(c => c.Bookmarks).HasForeignKey(x => x.CollectionId);
        }
    }
}
