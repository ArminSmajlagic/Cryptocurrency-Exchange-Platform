using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using database.trading.DB_Models.Kripto;
using database.trading.DB_Models.Security;
using database.trading.DB_Models.Trading;
using database.trading.DB_Models.User;
using database.trading.DB_Models.User.Wallet;
using Microsoft.Extensions.DependencyInjection;

namespace database.trading
{
    public class PleskdbContext : DbContext
    {
        private readonly IConfiguration config;
        private readonly DatabaseContext context;
        public PleskdbContext(IConfiguration config, DatabaseContext context) : base()
        {
            this.config = config;
            this.context = context;

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
            if (!optionsBuilder.IsConfigured)
            {
                if (!string.IsNullOrEmpty(config.GetConnectionString("deployed_db")))
                    optionsBuilder.UseSqlServer(config.GetConnectionString("deployed_db"), builder => builder.EnableRetryOnFailure());
            }
        }


        public async void SeedData()
        {
            if (context.ponude.Count() > 0)
                return;

            var ponudePlesk = ponude.ToList();

            var valutePlesk = valute.ToList();

            foreach (var ponuda in ponudePlesk)
            {
                var ponuda_id = ponuda.id;
                ponuda.id = 0;
                var respons = context.ponude.Add(ponuda);

                context.SaveChanges();

                var valutePonude = valute.Where(x => x.ponudaId == ponuda_id);

                foreach (var valuta in valutePonude)
                {

                    var valuta_id = valuta.valuta_id;
                    valuta.ponudaId = respons.Entity.id;
                    valuta.valuta_id = 0;

                    var valutaInserted = context.valute.Add(valuta);

                    context.SaveChanges();

                    var histPodaciePlesk = histPodaci.Where(x => x.valutaId == valuta_id); ;

                    foreach (var podaci in histPodaciePlesk)
                    {
                        podaci.valutaId = valutaInserted.Entity.valuta_id;

                        podaci.id = 0;

                        context.histPodaci.Add(podaci);

                        context.SaveChanges();
                    }
                }
            }

            foreach (var user in korisnici.Include(x=>x.authUser).ToList())
            {
                var authKorisnik = user.authUser;

                authKorisnik.id = 0;

                var result = context.auth_korisnici.Add(authKorisnik);

                context.SaveChanges();


                var user_id = user.user_id;

                user.user_id = 0;
                user.authUserId = result.Entity.id;

                var korisnik = context.korisnici.Add(user);

                context.SaveChanges();              


                var wallet = walleti.ToList().Find(x => x.userId == user_id);

                var wallet_id  = wallet.id;

                wallet.userId = korisnik.Entity.user_id;
                wallet.id = 0;

                context.walleti.Add(wallet);

                context.SaveChanges();

                var imovine_vlasnika = wallet_imovine.Where(x => x.walletId == wallet_id);

                foreach (var imovina in imovine_vlasnika)
                {
                    imovina.id = 0;

                    imovina.valuta_id = context.valute.First(x=>x.naziv == imovina.naziv_valute).valuta_id;

                    context.wallet_imovine.Add(imovina);

                    context.SaveChanges();
                }

            };

            context.wallet_transakcije.AddRange(new List<walletTransakcija>() {
                 new walletTransakcija(){
                    walletId = 1,
                    vrijeme_obavljanja = DateTime.Now,
                    kolicina_transakcije = 5000,
                    tip_transakcije_id = 0,
                    tip_metode_id = 1,
                    wcash = 5000,
                                        naziv_valute = "USD"

                },
                new walletTransakcija(){ 
                    walletId = 2,
                    vrijeme_obavljanja = DateTime.Now,
                    kolicina_transakcije = 5000,
                    tip_transakcije_id = 0,
                    tip_metode_id = 1,
                    wcash = 6000,
                                        naziv_valute = "USD"

                },
                new walletTransakcija(){
                    walletId = 2,
                    vrijeme_obavljanja = DateTime.Now,
                    kolicina_transakcije = 1000,
                    tip_transakcije_id = 1,
                    tip_metode_id = 1,
                    wcash = 1000,
                                        naziv_valute = "USD"

                },
                new walletTransakcija(){
                    walletId = 3,
                    vrijeme_obavljanja = DateTime.Now,
                    kolicina_transakcije = 5000,
                    tip_transakcije_id = 0,
                    tip_metode_id = 1,
                    wcash = 5000,
                    naziv_valute = "USD"
                }
            });

            context.SaveChanges();


            context.narudzbe.AddRange(new List<narudzba>() {

                new narudzba(){
                    
                    kreirana = DateTime.Now,
                    userId = 2,
                    valutaId = 2,
                    state = "kreirana",
                    cijena = 439.3155,
                    kolicina = 0.01,
                    tip = 0
                },
                new narudzba(){
                    kreirana = DateTime.Now,
                    userId = 2,
                    valutaId = 2,
                    state = "izvrsena",
                    cijena = 439.3155,
                    kolicina = 0.01,
                    tip = 1
                },
                new narudzba(){
                    kreirana = DateTime.Now,
                    userId = 3,
                    valutaId = 2,
                    state = "izvrsena",
                    cijena = 439.3155,
                    kolicina = 0.01,
                    tip = 0
                },
                new narudzba(){
                    kreirana = DateTime.Now,
                    userId = 2,
                    valutaId = 2,
                    state = "odbijena",
                    cijena = 439.3155,
                    kolicina = 0.01,
                    tip = 0
                },
            });

            context.SaveChanges();


        }



    }
}
