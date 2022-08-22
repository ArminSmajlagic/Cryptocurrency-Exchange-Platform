using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.trading.DB_Models.Kripto
{
    public class historijskiPodaci
    {
        [Key]
        public int id { get; set; }
        public string date { get; set; }
        public double high { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public int volume { get; set; }
        public int market_cap { get; set; }
        public int? valutaId { get; set; }
        public valuta? valuta { get; set; }
    }
}
