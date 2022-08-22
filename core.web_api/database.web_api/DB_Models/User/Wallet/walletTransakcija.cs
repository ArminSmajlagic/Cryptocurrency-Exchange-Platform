namespace database.trading.DB_Models.User.Wallet
{
    public enum tip_wallet_transakcije
    {
        depozit = 0,
        withdraw = 1
    }

    public enum tip_metode_transakcije
    {
        bank_transfer = 0,
        kartica = 1,
        paypal = 2,
        cryptoNetwork = 3
    }
    public class walletTransakcija
    {
        [Key]
        public int id { get; set; }
        public int walletId { get; set; }
        public wallet wallet { get; set; }
        public DateTime vrijeme_obavljanja { get; set; }
        public double kolicina_transakcije { get; set; } //fiat valuta
        public double wcash { get; set; } //in-app cash
        public string naziv_valute { get; set; } // fiat valuta
        public int tip_transakcije_id { get; set; }
        public int tip_metode_id { get; set; }

    }

}
