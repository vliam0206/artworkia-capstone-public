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
        builder.HasMany(x => x.CategoryServiceDetails).WithOne(d => d.Service).HasForeignKey(d => d.CategoryId);
    }
}
