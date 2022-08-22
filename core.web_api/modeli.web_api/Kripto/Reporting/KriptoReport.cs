using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Kripto.Reporting
{
    public class KriptoReport
    {
        public double openAvg { get; set; }
        public double closeAvg { get; set; }
        public double lowAvg { get; set; }
        public double highAvg { get; set; }
        public int rank { get; set; }
        public double cap { get; set; }
        public double volume { get; set; }
    }
}
