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
                ServiceId = Guid.Parse("1c8542d4-41bd-492b-9d21-905c6a8b0532"),
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
            }
        );
        #endregion
    }
}
