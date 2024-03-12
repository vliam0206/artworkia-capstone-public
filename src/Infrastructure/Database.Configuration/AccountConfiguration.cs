using Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Application.Commons;
using Domain.Enums;
using MassTransit;
using static System.Net.WebRequestMethods;

namespace Infrastructure.Database.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.Property(x => x.Id).HasDefaultValueSql("newid()");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.LastModificatedOn).HasDefaultValueSql("getutcdate()");

        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        #region relationships
        builder.HasOne(x => x.Wallet).WithOne(w => w.Account).HasForeignKey<Wallet>(x => x.AccountId);
        builder.HasMany(x => x.ChatBoxes_1).WithOne(c => c.Account_1).HasForeignKey(c => c.AccountId_1);
        builder.HasMany(x => x.ChatBoxes_2).WithOne(c => c.Account_2).HasForeignKey(c => c.AccountId_2);
        builder.HasMany(x => x.Messages).WithOne(m => m.Account).HasForeignKey(m => m.CreatedBy);
        builder.HasMany(x => x.Proposals).WithOne(p => p.Account).HasForeignKey(p => p.CreatedBy);
        builder.HasMany(x => x.Reviews).WithOne(r => r.Account).HasForeignKey(r => r.CreatedBy);
        builder.HasMany(x => x.Services).WithOne(s => s.Account).HasForeignKey(s => s.CreatedBy);
        builder.HasMany(x => x.Requests).WithOne(r => r.Account).HasForeignKey(r => r.CreatedBy);
        builder.HasMany(x => x.UserTokens).WithOne(t => t.User).HasForeignKey(t => t.UserId);
        builder.HasMany(x => x.Artworks).WithOne(a => a.Account).HasForeignKey(a => a.CreatedBy);
        builder.HasMany(x => x.Notifications).WithOne(n => n.Account).HasForeignKey(n => n.SentToAccount);
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Account).HasForeignKey(t => t.CreatedBy);
        builder.HasMany(x => x.Likes).WithOne(l => l.Account).HasForeignKey(l => l.AccountId);
        builder.HasMany(x => x.Comments).WithOne(c => c.Account).HasForeignKey(c => c.CreatedBy);
        builder.HasMany(x => x.Followings).WithOne(f => f.Account).HasForeignKey(f => f.AccountId);
        builder.HasMany(x => x.Followers).WithOne(f => f.Follower).HasForeignKey(f => f.FollowerId);
        builder.HasMany(x => x.WalletHistories).WithOne(h => h.Account).HasForeignKey(h => h.CreatedBy);
        builder.HasMany(x => x.Milestones).WithOne(m => m.CreatedAccount).HasForeignKey(m => m.CreatedBy);
        #endregion

        #region init data
        builder.HasData(
            // users
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "user",
                Password = "/Yvo/zNSPcJB+6Roi0BD6gR/tx9tPXSqrslB+3Zy0rwOC2lA", //12345
                Fullname = "Ngư�?i dùng mặc định",
                Email = "user@example.com",
                Bio = "Tôi là ngư�?i dùng mặc định",
                Avatar = "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg",
                Birthdate = DateTime.Parse("2000-10-14"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-14T05:37:42.345Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Username = "lamlam",
                Password = "P9i8PUWQ4DnT6Dnstg7HEXTlnFUDoZFTNJopEJ4UxxoK3zRn", //12345
                Fullname = "Trúc Lam Võ",
                Email = "lamlam@example.com",
                Bio = "Tôi là Trúc Lam Võ, tôi là một nghệ sĩ đầy tài năng",
                Avatar = "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg",
                Birthdate = DateTime.Parse("2002-10-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-15T10:15:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Username = "hoanganh",
                Password = "RZX95v+qA/O+EKXLkilrMbLW+cKQ7jekrOE9uwWE4fSupbQM", //12345
                Fullname = "�?ặng Hoàng Anh",
                Email = "hoanganh@example.com",
                Bio = "Tôi là �?ặng Hoàng Anh, tôi là một nghệ sĩ đầy tài năng",
                Avatar = "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg",
                Birthdate = DateTime.Parse("2002-10-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-21T12:20:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Username = "thong",
                Password = "BCpA8roVqTkU54PKIBXU4Iyl3YqyF5wYPagAXZ/1HYFEB9dh", //12345
                Fullname = "Nguyễn Trung Thông",
                Email = "thong@example.com",
                Bio = "Tôi là Nguyễn Trung Thông, tôi là một nghệ sĩ đầy tài năng",
                Avatar = "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg",
                Birthdate = DateTime.Parse("2002-1-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-27T12:23:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Username = "phuhuynh",
                Password = "44p9oaVq2ED8i7Q6vKIaS//ynDYqhnLcHcX/W7sDDIa1m3v/", //12345 
                Fullname = "Huỳnh Vạn Phú",
                Email = "phu@example.com",
                Bio = "Tôi là Huỳnh Vạn Phú, tôi là một nghệ sĩ đầy tài năng",
                Avatar = "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg",
                Birthdate = DateTime.Parse("2002-5-6"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-30T03:21:47.890Z")
            },
            // moderators
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Username = "mod",
                Password = "/yI89eEokmyCtc8FQcA8Salpuc2Gnv6+xvWUi9jfF3D56K8l", //12345
                Fullname = "Kiểm soát viên",
                Email = "mod@example.com",
                Bio = "Tôi là kiểm soát viên hệ thống",
                Avatar = "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg",
                Birthdate = DateTime.Parse("2001-10-4"),
                Role = RoleEnum.Moderator,
                CreatedOn = DateTime.Parse("2023-09-14T05:37:42.345Z")
            },
            // admin
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Username = "admin",
                Password = "tmb/sYLga1PDxUtRiIEU4YJtaG2HN58av/VA2S/8v19GLbSx", //12345
                Fullname = "Quản trị viên hệ thống",
                Email = "admin@example.com",
                Bio = "Tôi là quản trị viên hệ thống",
                Avatar = "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg",
                Birthdate = DateTime.Parse("2000-10-4"),
                Role = RoleEnum.Admin,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Username = "nguyenhoang",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Nguyễn Hoàng",
                Email = "nguyenhoang@example.com",
                Bio = "Tôi là một thiết kế UI/UX tài năng, đã có nhi�?u dự án thành công với " +
                "các công ty lớn, cũng là ngư�?i sáng lập một công ty thiết kế đồ h�?a.",
                Avatar = "https://i.pinimg.com/564x/79/ba/4f/79ba4f6c73168efb975a2d43cc4272a3.jpg",
                Birthdate = DateTime.Parse("2002-10-12"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Username = "tranminh",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Trần Minh",
                Email = "tranminh@example.com",
                Bio = "Tôi là một nhà thiết kế web có kinh nghiệm, đã tham gia vào nhi�?u " +
                "dự án phức tạp và mang lại sự sáng tạo đặc biệt.",
                Avatar = "https://i.pinimg.com/564x/79/ba/4f/79ba4f6c73168efb975a2d43cc4272a3.jpg",
                Birthdate = DateTime.Parse("2002-10-24"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000a"),
                Username = "phamthanh",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Phạm Thanh",
                Email = "phamthanh@example.com",
                Bio = "Tôi là một thiết kế 2D và 3D, đã tạo ra nhi�?u tác phẩm ấn tượng " +
                "trong lĩnh vực phim hoạt hình và trò chơi điện tử.",
                Avatar = "https://i.pinimg.com/564x/62/4a/2f/624a2fda3e0da8e55b4ea60b0949affa.jpg",
                Birthdate = DateTime.Parse("2000-10-5"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000b"),
                Username = "ngothanhtu",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Ngô Thanh Tú",
                Email = "ngothanhtu@example.com",
                Bio = "Tôi là một h�?a sĩ chuyên v�? tranh kỹ thuật số, đã có nhi�?u triển lãm cá nhân " +
                "và tham gia vào dự án nghệ thuật trên toàn thế giới.",
                Avatar = "https://i.pinimg.com/564x/8f/52/88/8f5288392e58e7f69adecfdd1bb1d896.jpg",
                Birthdate = DateTime.Parse("2001-1-1"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                Username = "truongthu",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Trương Thu",
                Email = "truongthu@example.com",
                Bio = "Tôi là một thiết kế đồ h�?a sáng tạo, đã tham gia vào nhi�?u dự án quảng cáo và " +
                "branding cho các thương hiệu lớn.",
                Avatar = "https://i.pinimg.com/564x/ad/c2/95/adc2953d7533371d1cdb95303d70babe.jpg",
                Birthdate = DateTime.Parse("2002-7-2"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000d"),
                Username = "levan",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Lê Văn",
                Email = "levan@example.com",
                Bio = "Tôi là một nhiếp ảnh gia có tên tuổi, đã chụp nhi�?u bức ảnh độc đáo v�? văn " +
                "hóa và cảnh đẹp Việt Nam.",
                Avatar = "https://i.pinimg.com/564x/9c/28/19/9c2819e41426236d748392299cd20246.jpg",
                Birthdate = DateTime.Parse("2002-8-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000e"),
                Username = "nguyenminh",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Nguyễn Minh",
                Email = "nguyenminh@example.com",
                Bio = "Tôi là một nhà thiết kế đồ h�?a sáng tạo, đã tham gia vào nhi�?u dự án " +
                "quảng cáo, in ấn và branding.",
                Avatar = "https://i.pinimg.com/564x/ae/ca/78/aeca78f2453767acdbd8398c4f310025.jpg",
                Birthdate = DateTime.Parse("2002-3-6"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000000f"),
                Username = "hoangtuan",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Hoàng Tuấn",
                Email = "hoangtuan@example.com",
                Bio = "Tôi là một h�?a sĩ có gu thẩm mỹ độc đáo, tạo ra những tác phẩm nghệ " +
                "thuật đa dạng và phong phú.",
                Avatar = "https://i.pinimg.com/564x/2a/1c/40/2a1c400fa2d814b78ed36fd21a5316f5.jpg",
                Birthdate = DateTime.Parse("2002-12-24"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-09-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Username = "buiduong",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Bùi Dương",
                Email = "buiduong@example.com",
                Bio = "Tôi là một thiết kế đồ h�?a trẻ tuổi nhưng tài năng, đã tham gia vào nhi�?u " +
                "dự án sáng tạo và độc đáo.",
                Avatar = "https://i.pinimg.com/564x/10/3a/ed/103aed482f200ba1af9a50a2392a83f0.jpg",
                Birthdate = DateTime.Parse("1999-10-14"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Username = "phamha",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Phạm Hà",
                Email = "phamha@example.com",
                Bio = "Tôi là một h�?a sĩ chuyên v�? tranh nghệ thuật, tạo ra những tác phẩm tươi " +
                "sáng và lôi cuốn.",
                Avatar = "https://i.pinimg.com/564x/17/f4/97/17f497af6f6b67bd9dbcb93c04dced89.jpg",
                Birthdate = DateTime.Parse("2003-10-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Username = "doantrang",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "�?oàn Trang",
                Email = "doantrang@example.com",
                Bio = "Tôi là là một thiết kế UI/UX đam mê và sáng tạo, đã tham gia vào nhi�?u " +
                "dự án thành công trong lĩnh vực công nghệ.",
                Avatar = "https://i.pinimg.com/564x/ba/74/40/ba744092fe6e7222d44a5e89cf483d6d.jpg",
                Birthdate = DateTime.Parse("2002-10-7"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Username = "tranduc",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Trần �?ức",
                Email = "tranduc@example.com",
                Bio = "Tôi là một nghệ sĩ 3D tài năng, đã tham gia vào việc tạo ra các mô " +
                "hình 3D ấn tượng cho phim và trò chơi.",
                Avatar = "https://i.pinimg.com/564x/de/09/b1/de09b1839700e9988e605df833a5450a.jpg",
                Birthdate = DateTime.Parse("2002-10-3"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Username = "nguyenhieu",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Nguyễn Hiếu",
                Email = "nguyenhieu@example.com",
                Bio = "Tôi là một nhà thiết kế đồ h�?a có tầm nhìn sáng tạo, đã đạt được " +
                "nhi�?u giải thưởng trong ngành.",
                Avatar = "https://i.pinimg.com/564x/1e/a0/59/1ea05967bf1e5e2054aaecd109a3c662.jpg",
                Birthdate = DateTime.Parse("2003-12-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                Username = "vuthao",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Vũ Thảo",
                Email = "vuthao@example.com",
                Bio = "Tôi là một h�?a sĩ trẻ có sức sáng tạo và tinh thần nghệ thuật cao, " +
                "đã tham gia vào nhi�?u dự án nghệ thuật và thiết kế.",
                Avatar = "https://i.pinimg.com/564x/7b/78/42/7b784268d117a6d57a8d9a83c7eaa977.jpg",
                Birthdate = DateTime.Parse("2002-6-20"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Username = "nguyentien",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Nguyễn Tiến",
                Email = "nguyentien@example.com",
                Bio = "Tôi là một nhà thiết kế đồ h�?a có kinh nghiệm, đã tham gia vào việc " +
                "phát triển các ứng dụng di động và giao diện ngư�?i dùng.",
                Avatar = "https://i.pinimg.com/564x/7b/78/42/7b784268d117a6d57a8d9a83c7eaa977.jpg",
                Birthdate = DateTime.Parse("2004-11-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            },
            new Account()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                Username = "vudang",
                Password = "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", //***REMOVED***
                Fullname = "Vũ �?ăng",
                Email = "vudang@example.com",
                Bio = "Tôi là một h�?a sĩ nổi tiếng với phong cách nghệ thuật độc đáo và sáng tạo. " +
                "�?ã tham gia vào nhi�?u triển lãm nghệ thuật quốc tế và được biết đến với các tác phẩm nổi bật.",
                Avatar = "https://i.pinimg.com/564x/f9/7f/c4/f97fc4762b0ca1c3ba76c3b2e6c5041c.jpg",
                Birthdate = DateTime.Parse("2002-4-4"),
                Role = RoleEnum.CommonUser,
                CreatedOn = DateTime.Parse("2023-10-02T03:21:47.890Z")
            }
        );
        #endregion
    }
}
