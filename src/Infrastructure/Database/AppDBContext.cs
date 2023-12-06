using Application.Commons;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Database;

public class AppDBContext : DbContext
{
    private readonly AppConfiguration _config;
    public AppDBContext(AppConfiguration config) => _config = config;

    public AppDBContext(DbContextOptions options, AppConfiguration config) : base(options)  
        => _config = config;

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ChatBox> ChatBoxes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<ProposalAsset> ProposalAssets { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletHistory> WalletHistories { get; set; }
    public DbSet<CategoryServiceDetail> CategoryServiceDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use local sqlserver
        optionsBuilder.UseSqlServer(_config.ConnectionStrings.MSSQLServerDB,
                        x => x.MigrationsAssembly("Migrators.MSSQL"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
