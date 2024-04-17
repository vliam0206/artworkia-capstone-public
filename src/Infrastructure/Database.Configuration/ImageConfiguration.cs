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

            // artwork 1
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Location = "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-000000000001_i0.jpg",
                Order = 0
            },

            // artwork 2
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Location = "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000002_i0.jpg",
                Order = 0
            },

            // artwork 3
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Location = "https://vov2-media.solidtech.vn/sites/default/files/styles/large/public/2022-05/dien-bien-phu_-_bia.jpg",
                ImageName = "00000000-0000-0000-0000-000000000003_i0.jpg",
                Order = 0
            },

            // artwork 4
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Location = "https://bizweb.dktcdn.net/100/378/894/files/5.jpg?v=1627978886825",
                ImageName = "00000000-0000-0000-0000-000000000004_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Location = "https://bizweb.dktcdn.net/100/378/894/files/4.jpg?v=1627978828806",
                ImageName = "00000000-0000-0000-0000-000000000004_i1.jpg",
                Order = 1
            },

            // artwork 5
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Location = "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000005_i0.jpg",
                Order = 0
            },

            // artwork 6
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Location = "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000006_i0.jpg",
                Order = 0
            },

            // artwork 7
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Location = "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000007_i0.jpg",
                Order = 0
            },

            // artwork 8
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Location = "https://static-company.waka.vn/img.media/tin%20t%E1%BB%A9c/38540.jpg",
                ImageName = "00000000-0000-0000-0000-000000000008_i0.jpg",
                Order = 0
            },

            // artwork 9
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Location = "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000009_i0.jpg",
                Order = 0
            },

            // artwork 10
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                Location = "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-00000000000a_i0.jpg",
                Order = 0
            },

            // artwork 11
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                Location = "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain",
                ImageName = "00000000-0000-0000-0000-00000000000b_i0.jpg",
                Order = 0
            },

            // artwork 12
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                Location = "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-00000000000c_i0.jpg",
                Order = 0
            },

            // artwork 13
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                Location = "https://i.pinimg.com/originals/7f/b2/ab/7fb2abc0dddd2aa40a86ce6c318b369a.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000d_i0.jpg",
                Order = 0
            },

            // artwork 14
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/b5/7e/14/b57e14aa401d41db2072d1b0ccfbde2b.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i1.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Location = "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000e_i2.jpg",
                Order = 2
            },

            // artwork 15
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Location = "https://i.pinimg.com/originals/db/93/a1/db93a131d59201ed997d606ea33c4933.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000f_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Location = "https://i.pinimg.com/originals/b5/d4/7e/b5d47e1cf4555983a8017e59409b4d4a.jpg",
                ImageName = "00000000-0000-0000-0000-00000000000f_i1.jpg",
                Order = 1
            },

            // artwork 16
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000027"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Location = "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn",
                ImageName = "00000000-0000-0000-0000-000000000010_i0.jpg",
                Order = 0
            },

            // artwork 17 (bds)
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000029"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i0.jpg?alt=media&token=e9a93f6f-4bcf-4517-824a-dacd402bdcec",
                ImageName = "00000000-0000-0000-0000-000000000011_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002a"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i1.jpg?alt=media&token=3442240e-37f5-42f9-be58-5c359ebcde5c",
                ImageName = "00000000-0000-0000-0000-000000000011_i1.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002b"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F00000000-0000-0000-0000-000000000011_i2.jpg?alt=media&token=4d6ad124-294d-4059-b21d-a37cfb3d0c6a",
                ImageName = "00000000-0000-0000-0000-000000000011_i2.jpg",
                Order = 2
            },

            // artwork 18
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002d"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F1.png?alt=media&token=61dea5b6-4462-49b3-b58a-3acc6f9861fc",
                ImageName = "00000000-0000-0000-0000-000000000012_i0.png",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002e"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F2.png?alt=media&token=10e991c2-11ac-469b-9933-3b223fe17f5b",
                ImageName = "00000000-0000-0000-0000-000000000012_i1.png",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000002f"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F3.png?alt=media&token=13f47f61-2372-4b87-b8f4-806c5ef956ee",
                ImageName = "00000000-0000-0000-0000-000000000012_i2.png",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F4.png?alt=media&token=53a9b98e-1875-48d6-a880-6b935081afe5",
                ImageName = "00000000-0000-0000-0000-000000000012_i3.png",
                Order = 3
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F5.png?alt=media&token=4d9137a2-5836-4cee-8e36-c1b87f9236c6",
                ImageName = "00000000-0000-0000-0000-000000000012_i4.png",
                Order = 4
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000032"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F6.png?alt=media&token=3b05c46f-6ed0-42d6-aa84-1ef96a880f99",
                ImageName = "00000000-0000-0000-0000-000000000012_i4.png",
                Order = 5
            },

            // artwork 19
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000034"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Location = "https://vov2.vov.vn/sites/default/files/styles/large/public/2022-05/vo-nguyen-giap.jpg",
                ImageName = "00000000-0000-0000-0000-000000000013_i0.png",
                Order = 0
            },

            // artwork 20
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000035"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Location = "https://public-files.gumroad.com/ydorwqbnmsl1yueuyhnr90ceo7sq",
                ImageName = "00000000-0000-0000-0000-000000000014_i0.png",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000036"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Location = "https://public-files.gumroad.com/1tmubanfhbhfs7fi4mwbw1s5nyc0",
                ImageName = "00000000-0000-0000-0000-000000000014_i1.png",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000037"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Location = "https://public-files.gumroad.com/7ml9boypxaoisvvaio5eajau57ts",
                ImageName = "00000000-0000-0000-0000-000000000014_i2.png",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000038"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Location = "https://public-files.gumroad.com/t1tx8r7s2jhhedtr2zqyc3r9edc6",
                ImageName = "00000000-0000-0000-0000-000000000014_i3.png",
                Order = 3
            },

            // artwork 21
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000003a"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                Location = "https://yt3.ggpht.com/7CFh0HeCsVSD9UfK1LSc9imflCpKDZT41gNjj_qehvRKt0J9fgmjw2tYjf4oMpbsn0BagczFhx_TTQ=s1600-rw-nd-v1",
                ImageName = "00000000-0000-0000-0000-000000000015_i0.png",
                Order = 0
            },

            // artwork 22
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000003c"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Location = "https://yt3.ggpht.com/gD2jfNal37ZYf6zkA7CX8CdBQ3WJDP9wFxA-JgrTl0RMGmWh7QcaWG1L2dzBWHUV_qd20ddxXJSMi90=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1",
                ImageName = "00000000-0000-0000-0000-000000000016_i0.png",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000003d"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Location = "https://yt3.ggpht.com/soXomuCz4k_xBxpb_p6K7nAht6BlCfzh8p3PfTPU2dt3iGX25Ga-W-Noiow1GPr5ii9seYFsCci-=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1",
                ImageName = "00000000-0000-0000-0000-000000000016_i1.png",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000003e"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Location = "https://yt3.ggpht.com/An5n_i_kbv45-ijvkogN9T98slicRZYEsxmyallrHtsILGoNgwdOs0_93C94duiwdClNGWFtoG-f=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1",
                ImageName = "00000000-0000-0000-0000-000000000016_i2.png",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000003f"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Location = "https://yt3.ggpht.com/togZdny_IHrLbAa73ZmBXhUlt-Br4Rdrjpq2iySYPgt7S3bATckHvipkjv6gsDmjkJtXnM8DazDgPg=s1024-c-fcrop64=1,0000199affffe666-rw-nd-v1",
                ImageName = "00000000-0000-0000-0000-000000000016_i3.png",
                Order = 3
            },

            // artwork 23
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000040"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                Location = "https://firebasestorage.googleapis.com/v0/b/artworkia-init.appspot.com/o/Artwork%2FImage%2F106127234_p0.jpg?alt=media&token=86c5c12c-bee7-4a57-8db1-402e317d5c23",
                ImageName = "00000000-0000-0000-0000-000000000017_i0.png",
                Order = 0
            },

            // artwork 24
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000042"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                Location = "https://www.kiettacnghethuat.com/wp-content/uploads/Girl-With-a-Pearl-Earring.jpg",
                ImageName = "00000000-0000-0000-0000-000000000018_i0.png",
                Order = 0
            },

            // artwork 25
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000044"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                Location = "https://www.kiettacnghethuat.com/wp-content/uploads/The-Starry-Night.jpg",
                ImageName = "00000000-0000-0000-0000-000000000019_i0.jpg",
                Order = 0
            },

            // artwork 26
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000048"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001a"),
                Location = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg/800px-To_Ngoc_Van_thieu_nu_ben_hoa_hue.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001a_i0.jpg",
                Order = 0
            },

            // artwork 27
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000004a"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001b"),
                Location = "https://i.pinimg.com/originals/5b/43/fc/5b43fc89abad25aa3359bfe0f27923f9.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001b_i0.jpg",
                Order = 0
            },

            // artwork 28
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000004d"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001c"),
                Location = "https://upload.wikimedia.org/wikipedia/commons/e/e5/Adolf_Hitler_-_Wien_Oper.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001c_i0.jpg",
                Order = 0
            },

            // artwork 29
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000004e"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001d"),
                Location = "https://upload.wikimedia.org/wikipedia/commons/9/93/Adolf_Hitler_-_Hofbr%C3%A4uhaus.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001d_i0.jpg",
                Order = 0
            },

            // artwork 30
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000004f"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001e"),
                Location = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg/1024px-Adolf_Hitler_-_Standesamt_M%C3%BCnchen.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001e_i0.jpg",
                Order = 0
            },

            // artwork 31
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000050"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-00000000001f"),
                Location = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Adolf_Hitler_Der_Alte_Hof.jpg/1024px-Adolf_Hitler_Der_Alte_Hof.jpg",
                ImageName = "00000000-0000-0000-0000-00000000001f_i0.jpg",
                Order = 0
            },

            // artwork 32
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000051"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                Location = "https://i.upanh.org/2024/04/17/imagea564c74b940c1ce3.png",
                ImageName = "00000000-0000-0000-0000-000000000020_i0.png",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000052"),
                ArtworkId = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                Location = "https://i.upanh.org/2024/04/17/image689a466ed577378c.png",
                ImageName = "00000000-0000-0000-0000-000000000020_i1.png",
                Order = 1
            }
        );
        #endregion
    }
}
