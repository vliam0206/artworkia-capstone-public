using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;
public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable(nameof(Image));
        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.HasOne(x => x.Artwork).WithMany(w => w.Images).HasForeignKey(x => x.ArtworkId);


        #region init data
        builder.HasData
        (
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/b5/7e/14/b57e14aa401d41db2072d1b0ccfbde2b.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i1.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i2.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i3.jpg",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Location = "https://i.pinimg.com/originals/db/93/a1/db93a131d59201ed997d606ea33c4933.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000f_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Location = "https://i.pinimg.com/originals/b5/d4/7e/b5d47e1cf4555983a8017e59409b4d4a.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000f_i1.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Location = "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-000000000008_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Location = "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-000000000001_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Location = "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000002_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Location = "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-000000000003_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Location = "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-000000000004_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Location = "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000005_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Location = "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000006_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Location = "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000007_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Location = "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000009_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                Location = "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-00000000000a_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                Location = "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-00000000000b_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                Location = "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-00000000000c_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Location = "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000010_i0.jpg",
                Order = 0
            }


        );
        #endregion
    }
}
