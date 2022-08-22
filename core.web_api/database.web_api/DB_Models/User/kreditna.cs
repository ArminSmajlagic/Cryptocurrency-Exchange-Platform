namespace database.trading.DB_Models.User;
public class kreditna
{
    [Key]
    public int kreditna_id { get; set; }
    [MinLength(12)]
    [MaxLength(16)]
    public string broj_kartice { get; set; }
    //npr. mastercard, visa...
    public string naziv_izdavaca { get; set; }
    public DateTime datum_isteka { get; set; }
}

