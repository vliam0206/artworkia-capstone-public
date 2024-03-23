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
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "Đây là một bức tranh rất đẹp",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "Minh hoạ xuất sắc",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "10 điểm",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "Cute and funny",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "Like",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    CreatedOn = DateTime.Parse("2024-1-1"),
                },
                new Comment()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Content = "Hoàng hôn lấp lánh quá điiii!",
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    CreatedOn = DateTime.Parse("2024-3-21"),
                }
            );
            #endregion
        }
    }
}
