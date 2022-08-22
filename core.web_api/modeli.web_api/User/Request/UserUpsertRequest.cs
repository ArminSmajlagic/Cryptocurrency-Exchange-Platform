namespace modeli.trading.User.Request;
public class UserUpsertRequest
{
    public int user_id { get; set; }
    public string? ime_prezime { get; set; }
    public int spol { get; set; } //this prop is not necessary
    public string? username { get; set; }
    public string? lozinka { get; set; }
    public int? kreditna_id { get; set; }
    public string? email { get; set; }
    public string? broj_telefona { get; set; }
    public string? drzava { get; set; }
    public int authUserId { get; set; }
    public DateTime datum_kreiranja { get; set; }

}

