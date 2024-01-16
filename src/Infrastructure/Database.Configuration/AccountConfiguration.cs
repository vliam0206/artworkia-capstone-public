using Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Application.Commons;
using Domain.Enums;
using MassTransit;

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
        builder.HasMany(x => x.TransactionHistories).WithOne(t => t.Account).HasForeignKey(t => t.AccountId);
        builder.HasMany(x => x.Likes).WithOne(l => l.Account).HasForeignKey(l => l.AccountId);
        builder.HasMany(x => x.Comments).WithOne(c => c.Account).HasForeignKey(c => c.CreatedBy);
        builder.HasMany(x => x.Followings).WithOne(f => f.Account).HasForeignKey(f => f.AccountId);
        builder.HasMany(x => x.Followers).WithOne(f => f.Follower).HasForeignKey(f => f.FollowerId);
        #endregion

        #region init data
        builder.HasData
        (
            // users
            new Account() { 
                Id = Guid.Parse("7d580000-c214-88a4-cc1d-08dc1445b3e0"), 
                Username = "user", 
                Password = "12345".Hash(), 
                Fullname = "Người dùng mặc định", 
                Email = "user@example.com",
                Avatar = "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg", 
                Role = RoleEnum.CommonUser 
            },
            new Account() { 
                Id = Guid.Parse("7d580000-c214-88a4-3886-08dc1445b3e1"), 
                Username = "lamlam", 
                Password = "12345".Hash(),
                Fullname = "Trúc Lam Võ",
                Email = "lamlam@example.com",
                Avatar = "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg",
                Role = RoleEnum.CommonUser
            },
            new Account() {
                Id = Guid.Parse("7d580000-c214-88a4-a3f1-08dc1445b3e1"),
                Username = "hoanganh",
                Password = "12345".Hash(),
                Fullname = "Đặng Hoàng Anh",
                Email = "hoanganh@example.com",
                Avatar = "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg",
                Role = RoleEnum.CommonUser 
            },
            new Account() { 
                Id = Guid.Parse("7d580000-c214-88a4-0f12-08dc1445b3e2"), 
                Username = "thong", 
                Password = "12345".Hash(), 
                Fullname = "Nguyễn Trung Thông", 
                Email = "thong@example.com",
                Avatar = "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg",
                Role = RoleEnum.CommonUser
            },
            new Account() {
                Id = Guid.Parse("7d580000-c214-88a4-7ad3-08dc1445b3e2"),
                Username = "phuhuynh",
                Password = "12345".Hash(), 
                Fullname = "Huỳnh Vạn Phú", 
                Email = "phu@example.com", 
                Avatar = "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg", 
                Role = RoleEnum.CommonUser
            },
            // moderators
            new Account() {
                Id = Guid.Parse("7d580000-c214-88a4-e5f6-08dc1445b3e2"),
                Username = "mod",
                Password = "12345".Hash(), 
                Fullname = "Kiểm soát viên",
                Email = "mod@example.com",
                Avatar = "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg", 
                Role = RoleEnum.Moderator 
            },
            // admin
            new Account() {
                Id = Guid.Parse("7d580000-c214-88a4-5141-08dc1445b3e3"), 
                Username = "admin", 
                Password = "12345".Hash(), 
                Fullname = "Quản trị viên hệ thống", 
                Email = "admin@example.com", 
                Avatar = "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg",
                Role = RoleEnum.Admin 
            }
        );
        #endregion
    }
}
