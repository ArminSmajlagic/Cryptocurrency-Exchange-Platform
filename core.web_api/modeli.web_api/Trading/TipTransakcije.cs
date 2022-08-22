using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Trading;
public class TipTransakcije
{
    public int id { get; set; }
    public int naziv { get; set; } // [BUY,SELL]
    public int opis { get; set; } // kratki opis
    public int tip_placanja { get; set; } // [in app fiat,in app lCash, bank card or transfer]
}

