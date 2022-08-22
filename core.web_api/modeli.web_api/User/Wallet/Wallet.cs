using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.User.Wallet
{
    public class Wallet
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int? kreditnaId { get; set; }
        public Kreditna? kreditna { get; set; }
    }

    public class WalletImovina
    {
        public int id { get; set; }
        public string naziv_valute { get; set; }
        public int valuta_id { get; set; }
        public double kolicina_valute { get; set; }
        public int walletId { get; set; }
        public Wallet wallet { get; set; }
    }
}



