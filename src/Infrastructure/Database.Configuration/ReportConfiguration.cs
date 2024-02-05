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
                    Id = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                    ReportType = ReportTypeEnum.Harassment,
                    Reason = "this is sexual harrasment",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-eb45-08dc266225b8"),
                    ReportType = ReportTypeEnum.Impersonation,
                    Reason = "Inappropriate content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Accepted,
                    TargetId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-07T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-a111-08dc2662267b"),
                    ReportType = ReportTypeEnum.Harassment,
                    Reason = "Abuse of platform",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Declined,
                    TargetId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-7151-08dc26627e8b"),
                    ReportType = ReportTypeEnum.Other,
                    Reason = "Disallowed content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-28T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-0d90-08dc2662aa73"),
                    ReportType = ReportTypeEnum.InappropriateContent,
                    Reason = "Disallowed content",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-12-29T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-4a40-08dc26620bdc"),
                    ReportType = ReportTypeEnum.InappropriateContent,
                    Reason = "Not suitable",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-27T08:40:28.901Z"),
                },
                new Report()
                {
                    Id = Guid.Parse("7d580000-c214-88a4-4a40-08dc26621bdc"),
                    ReportType = ReportTypeEnum.Spam,
                    Reason = "This is spam",
                    ReportEntity = ReportEntityEnum.Artwork,
                    State = StateEnum.Waiting,
                    TargetId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                    CreatedBy = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), //lamlam
                    CreatedOn = DateTime.Parse("2023-11-28T08:40:28.901Z"),
                }
            );
            #endregion
        }
    }
}
