﻿using Domain.Entitites;
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
            // service 1
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ServiceName = "Dịch vụ thiết kế",
                Description = "Mô tả Dịch vụ thiết kế",
                DeliveryTime = "2 - 3 tuần",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 100000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                CreatedOn = DateTime.Parse("2024-1-2"),
                LastModificatedOn = DateTime.Parse("2024-1-2"),
                Thumbnail = "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png"
            },

            // service 2
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ServiceName = "Dịch vụ phát triển website",
                Description = "Mô tả Dịch vụ phát triển website",
                DeliveryTime = "4 - 6 tuần",
                NumberOfConcept = 3,
                NumberOfRevision = 3,
                StartingPrice = 150000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), // lamlam
                CreatedOn = DateTime.Parse("2024-1-3"),
                LastModificatedOn = DateTime.Parse("2024-1-3"),
                Thumbnail = "https://laptopdieplinh.com/uploads/7%20c%C3%B4ng%20c%E1%BB%A5%20ph%C3%A1t%20tri%E1%BB%83n%20website%20b%E1%BA%A1n%20c%E1%BA%A7n%20bi%E1%BA%BFt%20-%200.jpg"
            },

            // service 3
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ServiceName = "Dịch vụ thiết kế nhân vật trò chơi 2D",
                Description = "Dịch vụ thiết kế nhân vật trò chơi 2D, từ indie tới AAA",
                DeliveryTime = "1 - 2 tháng",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 100000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), //phuhuynh
                CreatedOn = DateTime.Parse("2024-1-5"),
                LastModificatedOn = DateTime.Parse("2024-1-5"),
                Thumbnail = "https://static.vecteezy.com/system/resources/previews/023/289/956/original/cute-monster-doodle-character-design-flat-illustration-suitable-for-poster-banner-mascot-or-event-related-template-free-vector.jpg"
            },

            // service 4
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ServiceName = "Dịch vụ thiết kế nhân vật trò chơi 3D",
                Description = "Dịch vụ thiết kế nhân vật trò chơi 3D, từ indie tới AAA",
                DeliveryTime = "3 - 4 tháng",
                NumberOfConcept = 2,
                NumberOfRevision = 2,
                StartingPrice = 120000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000005"), // phuhuynh
                CreatedOn = DateTime.Parse("2024-1-7"),
                LastModificatedOn = DateTime.Parse("2024-1-7"),
                Thumbnail = "https://masterbundles.com/wp-content/uploads/2023/11/media-2-816.jpg"
            },

            // service 5
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                ServiceName = "Phục chế chân dung liệt sĩ",
                Description = "Tôi không muốn làm việc phục dựng, phục chế ảnh như một động tác khô khan về kỹ thuật, " +
                "tôi còn muốn kể lại những câu chuyện thực tế về liệt sĩ bằng ngôn ngữ hội họa và nhiếp ảnh",
                DeliveryTime = "1 - 2 tuần",
                NumberOfConcept = 2,
                NumberOfRevision = 1,
                StartingPrice = 20000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000003"), // hoanganh
                CreatedOn = DateTime.Parse("2024-1-8"),
                LastModificatedOn = DateTime.Parse("2024-1-8"),
                Thumbnail = "https://media-cdn-v2.laodong.vn/storage/newsportal/2023/7/26/1221583/CAF7870B-5832-44DC-B.jpeg"
            },

            // service 6
            new Service()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                ServiceName = "Thiết kế hình ảnh khoa học viễn tưởng",
                Description = "Thiết kế hình ảnh khoa học viễn tưởng phong phú và độc đáo, tùy chỉnh cho không gian của bạn. " +
                "Từ các bức tranh tường tường đồ sộ đến các tác phẩm nghệ thuật nhỏ hơn, chúng tôi mang đến sự sáng tạo và " +
                "phong cách cho mọi dự án.",
                DeliveryTime = "1 - 2 tháng",
                NumberOfConcept = 3,
                NumberOfRevision = 2,
                StartingPrice = 50000,
                CreatedBy = Guid.Parse("00000000-0000-0000-0000-00000000000b"), // melodysheep
                CreatedOn = DateTime.Parse("2024-1-9"),
                LastModificatedOn = DateTime.Parse("2024-1-9"),
                Thumbnail = "https://cdn.musicbed.com/image/upload/c_fill,dpr_auto,f_auto,g_auto,q_40,w_1200,h_630/v1658956186/production/albums/9887"
            }


        );
        #endregion
    }
}
