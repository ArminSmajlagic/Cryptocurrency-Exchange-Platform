using modeli.trading.Kripto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Dashboard
{
    public class Report
    {
        public List<User.User> users { get; set; }
        public List<Trading.Narudzba> narudzbe { get; set; }
        public List<Valuta> valute { get; set; }
        public List<NovoRegistrovani> novoRegistrovani { get; set; }
    }

    public class NovoRegistrovani
    {
        public int brojKorisnika { get; set; }
        public string mjesec { get; set; }
    }
}
