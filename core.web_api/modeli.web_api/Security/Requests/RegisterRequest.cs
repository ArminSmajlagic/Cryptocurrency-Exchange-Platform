namespace modeli.trading.Security.Request;
public class RegisterRequest
{
    public string ime_prezime { get; set; }
    public int spol { get; set; }
    public string username { get; set; }
    public string lozinka { get; set; }
    public string email { get; set; }
    public string broj_telefona { get; set; }
    public string drzava { get; set; }
}