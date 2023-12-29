﻿using Application.Commons;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Infrastructure.Database;

public class AppDBContext : DbContext
{
    private readonly AppConfiguration _config;
    public AppDBContext(AppConfiguration config) => _config = config;

    public AppDBContext(DbContextOptions options, AppConfiguration config) : base(options)
    {
        _config = config;
        try
        {
            var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreater != null)
            {
                if (!databaseCreater.CanConnect())
                {
                    databaseCreater.Create();
                }
                if (!databaseCreater.HasTables())
                {
                    databaseCreater.CreateTables();
                }
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }    

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryArtworkDetail> CategoryArtworkDetails { get; set; }
    public DbSet<CategoryServiceDetail> CategoryServiceDetails { get; set; }
    public DbSet<ChatBox> ChatBoxes { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<ProposalAsset> ProposalAssets { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagDetail> TagDetails { get; set; }
    public DbSet<TransactionHistory> TransactionHistories { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletHistory> WalletHistories { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<Block> Blocks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // Use sqlserver
    //    optionsBuilder.UseSqlServer(_config.ConnectionStrings.MSSQLServerDB,
    //                    x => x.MigrationsAssembly("Migrators.MSSQL"));
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
