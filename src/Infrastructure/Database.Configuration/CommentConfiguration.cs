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
        }
    }
}
