using database.trading.DB_Models.User;
using Microsoft.Extensions.DependencyInjection;
using modeli.trading.User;
using modeli.trading.User.Request;
using servisi.trading.IRepos.Base;
using servisi.trading.Repos.User;
using Microsoft.Extensions.Configuration;
using servisi.trading.Repos;
using servisi.trading.Repos.Base;
using servisi.trading.IRepos.User;
using modeli.trading.Kripto;
using database.trading.DB_Models.Kripto;
using servisi.trading.Repos.Kripto;
using servisi.trading.IRepos.Kripto;
using servisi.web_api.IServisi.User;
using servisi.web_api.Servisi.Security.Auth;
using servisi.trading.Repos.Security;
using servisi.trading.Repos.Security.Verification;
using servisi.trading.IRepos.Mail;
using modeli.trading.Trading;
using database.trading.DB_Models.Trading;
using servisi.trading.Repos.Trading;
using servisi.trading.IRepos.User.Wallet;
using servisi.trading.Repos.User.Wallet;
using servisi.trading.IRepos.Trading;
using servisi.trading.StateMachine;
using modeli.trading.Trading.Requests;
using database.trading.DB_Models.SearchObjects;
using servisi.trading.Repos.Dashboard;

namespace servisi.trading;
public static class ServicesProvider
{
    public static IServiceCollection ProvideServices(this IServiceCollection services)
    {
        //baza podataka
        services.AddTransient<DatabaseContext>();
        
        //user
        services.AddTransient<IUserWriteServis, UserWriteServis>();
        services.AddTransient<IUserReadServis,UserReadServis>();

        //transakcije
        //services.AddTransient<IReadServis<Transakcija, transakcija, object>,ReadServis<Transakcija, transakcija, object>>();
        //services.AddTransient<IWriteServis<Transakcija, transakcija, modeli.trading.Trading.Requests.UpsertRequest>,WriteServis<Transakcija, transakcija, modeli.trading.Trading.Requests.UpsertRequest>>();
        //services.AddTransient<TransakcijaReadServis>();
        //services.AddTransient<TransakcijaWriteServis>();
        //services.AddTransient<IReadWriteServis<Transakcija,transakcija,object,object>,ReadWriteBaseServis<Transakcija, transakcija, object, object>>();

        //narudzbe
        services.AddTransient<INarudzbaServis,NarudzbaServis>();

        //dashboard
        services.AddTransient<ReportingServis>();

        
        //narudzba states
        services.AddTransient<BaseState>();
        services.AddTransient<KreiranaNarudzbaState>();
        services.AddTransient<AktivnaNarudzbaState>();
        services.AddTransient<OdbijenaNarudzbaState>();
        services.AddTransient<IzvrsenaNarudzbaState>();

        //valuta
        services.AddSingleton<IValuteServis, ValuteServis>();
        services.AddSingleton<IReadServis<Valuta, valuta, object>, ReadServis<Valuta, valuta, object>>();

        //ponuda
        services.AddTransient<IPonudeServis, PonudeServis>();
        services.AddTransient<IReadServis<Ponuda, ponuda, object>, ReadServis<Ponuda, ponuda, object>>();

        //auth
        services.AddTransient<IAuthServis, AuthServis>();
        services.AddTransient<TokenManager>();

        //email
        services.AddTransient<IEmailService, EmailServis>();
        services.AddTransient<SimpleCodeGenerator>();
        //services.AddSingleton<EmailConfiguration.EmailConfig>();

        //wallet
        services.AddTransient<IWalletServis, WalletServis>();

        //loging
        services.AddTransient<LoggerServis>();
        services.AddTransient<ILogger,LoggerServis>();

        //services.AddSingleton<IMapper>();
        return services;
    }
}

