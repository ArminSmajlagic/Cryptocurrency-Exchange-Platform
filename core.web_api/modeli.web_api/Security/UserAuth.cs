using System.ComponentModel.DataAnnotations.Schema;

namespace modeli.trading.Security;
public class UserAuth
{
    public int id { get; set; }
    public string username { get; set; }
    public string lozinka { get; set; }
    public Token token { get; set; }
}
