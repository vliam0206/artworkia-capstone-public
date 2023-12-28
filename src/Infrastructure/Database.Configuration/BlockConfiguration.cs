﻿using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.ToTable(nameof(Block));

        //composite key
        builder.HasKey(x => new { x.BlockingId, x.BlockedId });

        //relationship
        builder.HasOne(x => x.Blocking).WithMany(a => a.Blocking).HasForeignKey(x => x.BlockingId);
        builder.HasOne(x => x.Blocked).WithMany(a => a.Blocked)
            .HasForeignKey(x => x.BlockedId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
