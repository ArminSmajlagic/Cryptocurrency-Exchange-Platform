using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Trading.Requests
{
    public class UpsertRequest
    {
        public DateTime vrijeme_obavljanja { get; set; }
        public int user_id { get; set; }
        public int walletId { get; set; }
        public int? valutaId { get; set; }
        public int tipTransakcijeID { get; set; }
        public double kolicinaValute { get; set; } 
        public double placeno { get; set; } 
        public string nazivValutePlacanje { get; set; } 
    }
}
