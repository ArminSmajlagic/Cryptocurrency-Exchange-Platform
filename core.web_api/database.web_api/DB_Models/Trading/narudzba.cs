using database.trading.DB_Models.Kripto;
using database.trading.DB_Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.trading.DB_Models.Trading
{
    public class narudzba
    {
        public int id { get; set; }
        public DateTime kreirana { get; set; }
        public int userId { get; set; }
        public int valutaId { get; set; }
        public user user { get; set; }
        public valuta valuta { get; set; }
        public double kolicina { get; set; }
        public double cijena { get; set; }
        public string state { get; set; }
        public int tip { get; set; }
    }
}

