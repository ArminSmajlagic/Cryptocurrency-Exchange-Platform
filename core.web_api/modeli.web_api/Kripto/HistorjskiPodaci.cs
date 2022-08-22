using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Kripto
{
    public class HistorjskiPodaci
    {
        public int id { get; set; }
        public string date { get; set; }
        public double high { get; set; }
        public double open { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public int volume { get; set; }
        public int market_cap { get; set; }
        public int? valutaId { get; set; }
        public Valuta? valuta { get; set; }

    }
}
