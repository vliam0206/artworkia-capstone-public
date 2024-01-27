using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable(nameof(Request));
        
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Account).WithMany(a => a.Requests).HasForeignKey(x => x.CreatedBy);
        builder.HasOne(x => x.Service).WithMany(s => s.Requests).HasForeignKey(x => x.ServiceId);
        builder.HasOne(x => x.ChatBox).WithMany(c => c.Requests).HasForeignKey(x => x.ChatBoxId);

        builder.HasData
        (
            new Request()
            {
                Id = Guid.Parse("7d580000-c214-88a4-2ef8-08dc1ef3c2fb"),
                ServiceId = Guid.Parse("1c8542d4-41bd-492b-9d21-905c6a8b0532"),
                ChatBoxId = Guid.Parse("5bd4c5d0-bee0-4b9c-9396-9cb914a1294c"),
                Message = "yeu cau lam website ecommerce",
                Timeline = "2 - 3 tuần",
                RequestStatus = StateEnum.Waiting,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"),
                CreatedOn = DateTime.Parse("2024-1-2"),
            }   
        );
    }
}
