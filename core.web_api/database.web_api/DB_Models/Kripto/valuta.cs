namespace database.trading.DB_Models.Kripto;
public class valuta
{
    [Key]
    public int valuta_id { get; set; }
    public string naziv { get; set; } // npr. BITCOIN
    public string oznaka { get; set; } //-simbol npr. BTC
    public decimal vrijednost { get; set; } // trenutna vrijednost valute
    public string iternval { get; set; } // trenutna vrijednost valute
    public string datum { get; set; } //datum uzimanje vrijednosti
    public double promjena { get; set; } //promjena vrijednosti naspram intervala
    public string logo_url { get; set; } //logo valute
    public int rank { get; set; } //rank valute
    public double last_high { get; set; } //posljednja najviša vrijednost valute
    public int total_suplay { get; set; } //suma svih jedinki valute (ukupno postojanje valute)
    public int ponudaId { get; set; }
    public ponuda ponuda { get; set; }
}

