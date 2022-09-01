using database.trading.DB_Models.Kripto;
using database.trading.DB_Models.Security;
using database.trading.DB_Models.Trading;
using database.trading.DB_Models.User;
using database.trading.DB_Models.User.Wallet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using modeli.trading;

namespace database.trading;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration config;
    private readonly ILogger logger;
    public DatabaseContext(IConfiguration config, ILogger logger) : base()
    {
        this.config = config;
        this.logger = logger;

    }

    public DbSet<user> korisnici { get; set; }
    public DbSet<wallet> walleti { get; set; }
    public DbSet<wallet_imovina> wallet_imovine { get; set; }
    public DbSet<walletTransakcija> wallet_transakcije { get; set; }
    public DbSet<narudzba> narudzbe { get; set; }
    public DbSet<auth_user> auth_korisnici { get; set; }
    public DbSet<token> tokeni { get; set; }
    public DbSet<user_confirmation> user_confirmacije { get; set; }
    public DbSet<valuta> valute { get; set; }
    public DbSet<historijskiPodaci> histPodaci { get; set; }
    public DbSet<ponuda> ponude { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = config.GetConnectionString("sql_db");

        if (!optionsBuilder.IsConfigured)
        {
                optionsBuilder.UseSqlServer(connectionString, x => { 
                    x.EnableRetryOnFailure(); 
                });
        }
    }
    
}

