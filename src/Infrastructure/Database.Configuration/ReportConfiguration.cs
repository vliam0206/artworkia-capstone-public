using Domain.Entitites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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


            #region init data
            builder.HasData
            (
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ReportType = ReportTypeEnum.Harassment,
                    Reason = "this is sexual harrasment",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ReportType = ReportTypeEnum.Impersonation,
                    Reason = "Inappropriate content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Accepted,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-07T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    ReportType = ReportTypeEnum.Harassment,
                    Reason = "Abuse of platform",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Declined,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    ReportType = ReportTypeEnum.Other,
                    Reason = "Disallowed content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-28T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    ReportType = ReportTypeEnum.InappropriateContent,
                    Reason = "Disallowed content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-29T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    ReportType = ReportTypeEnum.InappropriateContent,
                    Reason = "Not suitable",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    ReportType = ReportTypeEnum.Spam,
                    Reason = "This is spam",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000002"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-28T08:40:28.901Z"),
                }
            );
            #endregion
        }
    }
}
