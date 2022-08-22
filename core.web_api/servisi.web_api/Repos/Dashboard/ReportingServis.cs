using Microsoft.EntityFrameworkCore;
using modeli.trading.Dashboard;
using modeli.trading.Trading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.Repos.Dashboard
{
    public class ReportingServis
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public ReportingServis(DatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Report> GetReport()
        {
            var result = new Report();

            result.users = new List<modeli.trading.User.User>();
            result.narudzbe = new List<Narudzba>();

            var setKorisnika = context.korisnici.Include("authUser").ToList();
            var setImovina = context.wallet_imovine.Include("wallet").Where(x=>x.valuta_id==15).ToList();
            var set = context.wallet_imovine.Where(x=>x.valuta_id==15).ToList();
            var setNarudzbi = context.narudzbe.Include("valuta").Include("user").ToList();

            foreach (var korisnik in setKorisnika)
            {
                var balans = setImovina.FirstOrDefault(x => x.wallet.userId == korisnik.user_id);

                result.users.Add(new modeli.trading.User.User()
                {
                    username = korisnik.authUser.username,
                    stanje_walleta = balans.kolicina_valute,
                    datum_kreiranja = korisnik.datum_kreiranja
                });
            }

            foreach (var narudzba in setNarudzbi)
            {
                result.narudzbe.Add(new modeli.trading.Trading.Narudzba() { 
                    cijena = narudzba.cijena,
                    kolicina = narudzba.kolicina,
                    kreirana = narudzba.kreirana,
                    userIme =narudzba.user.ime_prezime,
                    valutaNaziv = narudzba.valuta.naziv
                });
            }

            result.valute = mapper.Map<List<modeli.trading.Kripto.Valuta>>(context.valute);

            result.novoRegistrovani = new List<NovoRegistrovani>();

            var mjeseci = new List<string>() { 
                "January",
                "February",
                "March",
                "April," ,
                "Mai" ,
                "Jun" ,
                "July" ,
                "August" ,
                "September" ,
                "October" ,
                "November" ,
                "December"
            };

            foreach (var mjesec in mjeseci)
            {
                var novoRegistrovani = new NovoRegistrovani()
                {
                    mjesec = mjesec,
                    brojKorisnika = 0
                };

                var index = mjeseci.IndexOf(mjesec);

                foreach (var korisnik in setKorisnika)
                {
                    if (index == korisnik.datum_kreiranja.Month - 1)
                        novoRegistrovani.brojKorisnika++;

                }

                result.novoRegistrovani.Add(novoRegistrovani);
            }

            return result;
        }


    }


}
