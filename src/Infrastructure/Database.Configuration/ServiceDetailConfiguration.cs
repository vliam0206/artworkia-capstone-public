using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;
public class ServiceDetailConfiguration : IEntityTypeConfiguration<ServiceDetail>
{
    public void Configure(EntityTypeBuilder<ServiceDetail> builder)
    {
        builder.ToTable(nameof(ServiceDetail));

        //composite key
        builder.HasKey(x => new { x.ServiceId, x.ArtworkId });

        //relationship
        builder.HasOne(x => x.Service).WithMany(a => a.ServiceDetails).HasForeignKey(x => x.ServiceId);
        builder.HasOne(x => x.Artwork).WithMany(a => a.ServiceDetails).HasForeignKey(x => x.ArtworkId);


        #region init data
        builder.HasData
        (
            new ServiceDetail()
            {
                ServiceId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
            }
        );
        #endregion
    }
}
