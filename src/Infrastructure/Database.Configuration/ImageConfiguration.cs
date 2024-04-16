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
                ImageName = "00000000-0000-0000-0000-00000000000e_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i1.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i2.jpg",
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
                Location = "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg",
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
            },

            // anh bds
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i0.jpg?alt=media&token=e9a93f6f-4bcf-4517-824a-dacd402bdcec",
                ImageName = "00000000-0000-0000-0000-000000000011_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i1.jpg?alt=media&token=3442240e-37f5-42f9-be58-5c359ebcde5c",
                ImageName = "00000000-0000-0000-0000-000000000011_i1.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i2.jpg?alt=media&token=4d6ad124-294d-4059-b21d-a37cfb3d0c6a",
                ImageName = "00000000-0000-0000-0000-000000000011_i2.jpg",
                Order = 2
            },

            // anh aw 17
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc",
                ImageName = "00000000-0000-0000-0000-000000000012_i0.png",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F2.png?alt=media&token=10e991c2-11ac-469b-9933-3b223fe17f5b",
                ImageName = "00000000-0000-0000-0000-000000000012_i1.png",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000026"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F3.png?alt=media&token=13f47f61-2372-4b87-b8f4-806c5ef956ee",
                ImageName = "00000000-0000-0000-0000-000000000012_i2.png",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000027"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F4.png?alt=media&token=53a9b98e-1875-48d6-a880-6b935081afe5",
                ImageName = "00000000-0000-0000-0000-000000000012_i3.png",
                Order = 3
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000028"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F5.png?alt=media&token=4d9137a2-5836-4cee-8e36-c1b87f9236c6",
                ImageName = "00000000-0000-0000-0000-000000000012_i4.png",
                Order = 4
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000029"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F6.png?alt=media&token=3b05c46f-6ed0-42d6-aa84-1ef96a880f99",
                ImageName = "00000000-0000-0000-0000-000000000012_i4.png",
                Order = 5
            },

            // image aw 18
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002a"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Location = "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg",
                ImageName = "00000000-0000-0000-0000-000000000013_i0.png",
                Order = 0
            }

        );
        #endregion
    }
}
