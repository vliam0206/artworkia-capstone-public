using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(nameof(Service));
        
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

        // relationship
        builder.HasOne(x => x.Account).WithMany(a => a.Services).HasForeignKey(x => x.CreatedBy);
        builder.HasMany(x => x.Requests).WithOne(r => r.Service).HasForeignKey(r => r.ServiceId);
        builder.HasMany(x => x.Proposals).WithOne(p => p.Service).HasForeignKey(p => p.ServiceId);
        builder.HasMany(x => x.CategoryServiceDetails).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);
        builder.HasMany(x => x.ServiceDetails).WithOne(d => d.Service).HasForeignKey(d => d.ServiceId);

        #region init data
        builder.HasData
        (
            new Service()
            {
                Id = Guid.Parse("1c8542d4-41bd-492b-9d21-905c6a8b0532"),
                ServiceName = "Dịch vụ thiết kế",
                Description = "Mô tả Dịch vụ thiết kế",
                DeliveryTime = "2 - 3 tuần",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 100000,
                CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                CreatedOn = DateTime.Parse("2024-1-2"),
                LastModificatedOn = DateTime.Parse("2024-1-2"),
                Thumbnail = "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png"
            }
        );
        #endregion
    }
}
