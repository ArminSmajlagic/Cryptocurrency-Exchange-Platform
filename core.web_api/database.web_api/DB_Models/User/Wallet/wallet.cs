using database.trading.DB_Models.Kripto;

namespace database.trading.DB_Models.User.Wallet
{

    public class wallet
    {
        public int id { get; set; }
        public int userId { get; set; }
        public user user { get; set; }
        public int? kreditnaId { get; set; }
        public kreditna? kreditna { get; set; }

    }

    public class wallet_imovina
    {
        public int id { get; set; }
        public string naziv_valute { get; set; }
        public int valuta_id { get; set; }

        public double kolicina_valute { get; set; }
        public int walletId { get; set; }
        public wallet wallet { get; set; }
    }

}

