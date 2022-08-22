using modeli.trading.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace modeli.trading.User;
public class User:UserAuth
{
    public int user_id { get; set; }
    public string ime_prezime { get; set; }
    public DateTime datum_kreiranja { get; set; }
    public int spol { get; set; }
    public double stanje_walleta { get; set; }
    public Kreditna? kartica { get; set; }
    public string email { get; set; }
    public string broj_telefona { get; set; }
    public string? drzava { get; set; }

}
