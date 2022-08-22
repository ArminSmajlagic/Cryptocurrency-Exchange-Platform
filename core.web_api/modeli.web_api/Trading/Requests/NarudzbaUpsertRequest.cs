using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Trading.Requests
{
    public class NarudzbaUpsertRequest
    {
        public DateTime? kreirana { get; set; }
        public int userId { get; set; }
        public int valutaId { get; set; }
        public double kolicina { get; set; }
        public double cijena { get; set; }
        public int tip { get; set; }
        public string? state { get; set; } = "not set";
    }
}
