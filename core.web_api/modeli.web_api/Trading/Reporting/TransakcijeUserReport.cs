using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Trading.Reporting
{
    public class TransakcijeUserReport
    {
        public double avgCijenaKupovine { get; set; }
        public double avgCijenaProdaje { get; set; }
        public double maxKupovina { get; set; }
        public double maxProdaja { get; set; }
        public int brKupovina { get; set; }
        public int brProdaja { get; set; }
        public int brTran { get; set; }
    }
}
