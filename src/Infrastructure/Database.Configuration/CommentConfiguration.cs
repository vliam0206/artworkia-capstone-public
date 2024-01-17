using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

            // relationship
            builder.HasOne(x => x.Reply).WithMany(p => p.Replies).HasForeignKey(x => x.ReplyId);
            builder.HasOne(x => x.Account).WithMany(a => a.Comments).HasForeignKey(x => x.CreatedBy);
            builder.HasOne(x => x.Artwork).WithMany(a => a.Comments).HasForeignKey(x => x.ArtworkId);


            #region init data
            builder.HasData
            (
                new Comment()
                {
                    Id = Guid.Parse("8ea03178-3cc7-40e5-9344-a6a96c492a42"),
                    ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                    Content = "Đây là một bức tranh rất đẹp",
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("74524095-a079-44b0-9e2a-a8e67ae6b06e"),
                    ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                    Content = "Minh hoạ xuất sắc",
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("457f3324-5594-4526-ab24-25c63e5ee7bd"),
                    ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                    Content = "10 điểm",
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("e05281fb-cfb2-4dc3-9be8-d8ae59016f9a"),
                    ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                    Content = "Cute and funny",
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("5075efb6-cd23-4cea-8882-2f5669c70ea7"),
                    ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                    Content = "Like",
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                }
            );
            #endregion
        }
    }
}
