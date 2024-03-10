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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ServiceId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ChatBoxId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Message = "yeu cau lam website ecommerce",
                Timeline = "2 - 3 tuần",
                RequestStatus = StateEnum.Waiting,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-2"),
            }   
        );
    }
}
