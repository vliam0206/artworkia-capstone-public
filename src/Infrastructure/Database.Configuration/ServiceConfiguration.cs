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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ServiceName = "Dịch vụ thiết kế",
                Description = "Mô tả Dịch vụ thiết kế",
                DeliveryTime = "2 - 3 tuần",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 100000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CreatedOn = DateTime.Parse("2024-1-2"),
                LastModificatedOn = DateTime.Parse("2024-1-2"),
                Thumbnail = "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png"
            },
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ServiceName = "Dịch vụ phát triển website",
                Description = "Mô tả Dịch vụ phát triển website",
                DeliveryTime = "4 - 6 tuần",
                NumberOfConcept = 3,
                NumberOfRevision = 3,
                StartingPrice = 150000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CreatedOn = DateTime.Parse("2024-1-3"),
                LastModificatedOn = DateTime.Parse("2024-1-3"),
                Thumbnail = "https://laptopdieplinh.com/uploads/7%20c%C3%B4ng%20c%E1%BB%A5%20ph%C3%A1t%20tri%E1%BB%83n%20website%20b%E1%BA%A1n%20c%E1%BA%A7n%20bi%E1%BA%BFt%20-%200.jpg"
            },
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ServiceName = "Dịch vụ in ấn",
                Description = "Mô tả Dịch vụ in ấn",
                DeliveryTime = "1 - 2 tuần",
                NumberOfConcept = 1,
                NumberOfRevision = 1,
                StartingPrice = 50000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-5"),
                LastModificatedOn = DateTime.Parse("2024-1-5"),
                Thumbnail = "https://channel.mediacdn.vn/2022/3/17/photo-1-1647512803989607433836.jpg"
            },
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ServiceName = "Dịch vụ quản lý dự án",
                Description = "Mô tả Dịch vụ quản lý dự án",
                DeliveryTime = "3 - 4 tuần",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 120000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                CreatedOn = DateTime.Parse("2024-1-7"),
                LastModificatedOn = DateTime.Parse("2024-1-7"),
                Thumbnail = "https://www.inandaiduong.com/wp-content/uploads/2015/01/dich-vu-thiet-ke-in-an.jpg"
            }
        );
        #endregion
    }
}
