using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable(nameof(Report));

            builder.Property(x => x.Id).HasDefaultValueSql("newid()");

            // relationship
            builder.HasOne(x => x.AccountReport).WithMany(p => p.Reports).HasForeignKey(x => x.CreatedBy);
        }
    }
}
