using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class ChatBoxConfiguration : IEntityTypeConfiguration<ChatBox>
{
    public void Configure(EntityTypeBuilder<ChatBox> builder)
    {
        builder.ToTable(nameof(ChatBox));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");

        // relationship
        builder.HasOne(x => x.Account_1).WithMany(a => a.ChatBoxes_1)
                                        .HasForeignKey(x => x.AccountId_1)
                                        .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Account_2).WithMany(a => a.ChatBoxes_2)            
                                        .HasForeignKey(x => x.AccountId_2)
                                        .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(x => x.Messages).WithOne(p => p.ChatBox).HasForeignKey(p => p.ChatBoxId);
        builder.HasMany(x => x.Proposals).WithOne(p => p.ChatBox).HasForeignKey(p => p.ChatBoxId);
        builder.HasMany(x => x.Requests).WithOne(r => r.ChatBox).HasForeignKey(r => r.ChatBoxId);

        builder.HasData
        (
            new ChatBox()
            {
                Id = Guid.Parse("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"),
                AccountId_1 = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lam
                AccountId_2 = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"), //phu
            },
            new ChatBox()
            {
                Id = Guid.Parse("5bd4c5d0-bee0-4b9c-9396-9cb914a1295c"),
                AccountId_1 = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lam
                AccountId_2 = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"), //anh
            },
            new ChatBox()
            {
                Id = Guid.Parse("5bd4c5d0-bee0-4b9c-9396-9cb914a1296c"),
                AccountId_1 = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lam
                AccountId_2 = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"), //thong
            }
        );
    }
}
