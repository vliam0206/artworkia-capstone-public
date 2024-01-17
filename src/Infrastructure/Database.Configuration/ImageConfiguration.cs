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
                Id = Guid.Parse("01aa2232-7628-4227-b034-1c1a32cad359"),
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                Location = "https://www.dtv-ebook.com/images/files_2/2023/022023/tam-ly-hoc-toi-pham-phac-hoa-chan-dung-ke-pham-toi-diep-hong-vu.jpg",
                ImageName = "35966d1a-9b08-4743-b1c3-474a58350f6e_i1.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("ae8fb7be-5c63-481e-b997-2ada5ac5392b"),
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                Location = "https://lh3.googleusercontent.com/QKQqZt0RivsBmyjwFI8EomO6YZ2-hnSsiwLdKG9btAiNhVjiwpKtzTiULFqTRCo5JUOe5t8f6Be_sZ9ZBYRD7v3EYwqzlkomHabN_LqntP61rVbqqk9wuQqgVY4Dmk7JseAHmjbNWRacbMJynaBXgCoYvcQzAuYPOgNj-P2CAEWroKZcieC2GDyal2x02Cw0izhqYNCnJAQLnEPSErSXgYNBoSb3KlmjHcev9zq2KXRaorp04_aKLN5-iewZ27ee9OWmSuwfvnGgjSK98rKdtGfnqw5U_1cp1R89brso1E8VCIhFGfRTKijJMdCtjE3VbpyO_3vI46D5UVbJZB3N-c0-DulKgbP1EFp5p_wbgBwL2AQVAgQCB2TJ1IS_hVKqVS1GZ3xsCleYb7xTkaqqcojQIbR1GYMxirT_u2jU6xHq6ycB2w6UPCo_DZJfVhieyZXzjpIa92pN-6UM4I-Ou54BnFpvANrOxfOWxblViYR43PrSdHgu5XGGQYg2SYKvuAqbzkpOLpcnyRQBxDPV6bCMURXDTvnmRQj1Rl_14MEW278wjOe-D39mATYeEO6Xfq445Wu9SUEcXd40soLtSNcun92XJ-j_0Dyr1Dd2argkutkMXgiqRHyZxN1hfadB_T1xQ3Ln9TA8oSRrYEmoUIXi4iS9XD08kj5FZf-slMLA_KQeYT7F2Alkx11IBq2aahNUlf1FTWykZVpyxAr0DNjCypS44Lbmqsdw7xfQzKT8WrLR=w400-h500-no",
                ImageName = "35966d1a-9b08-4743-b1c3-474a58350f6e_i2.jpg",
                Order = 1
            },
            new Image()
            {
                Id = Guid.Parse("ff16271c-c04a-4cec-b6f1-04b555659b5a"),
                ArtworkId = Guid.Parse("35966d1a-9b08-4743-b1c3-474a58350f6e"),
                Location = "https://vietbooks.info/attachments/upload_2023-2-3_11-29-1-png.19599/",
                ImageName = "35966d1a-9b08-4743-b1c3-474a58350f6e_i3.jpg",
                Order = 2
            },
            new Image()
            {
                Id = Guid.Parse("36208d9b-471a-4a88-be28-adabfd1f2ae5"),
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                Location = "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p0.png",
                ImageName = "72fbdead-0704-4f69-82ec-0cd09218fef9_i0.jpg",
                Order = 0
            },
            new Image()
            {
                Id = Guid.Parse("5d96552b-ff92-4064-8858-5e1e96ee9899"),
                ArtworkId = Guid.Parse("72fbdead-0704-4f69-82ec-0cd09218fef9"),
                Location = "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p1.png",
                ImageName = "72fbdead-0704-4f69-82ec-0cd09218fef9_i1.jpg",
                Order = 1
            }

        );
        #endregion
    }
}
