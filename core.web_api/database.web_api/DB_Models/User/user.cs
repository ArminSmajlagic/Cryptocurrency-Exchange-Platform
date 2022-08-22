using database.trading.DB_Models.Security;

namespace database.trading.DB_Models.User;

public class user 
{
    [Key]
    public int user_id { get; set; }
    public int spol { get; set; }
    public string ime_prezime { get; set; }
    public DateTime datum_rodjenja { get; set; }
    public DateTime datum_kreiranja { get; set; }
    [EmailAddress]
    public string email { get; set; }
    [Phone]
    public string broj_telefona { get; set; }
    public string? drzava { get; set; }
    public int authUserId { get; set; }
    public auth_user authUser { get; set; }

}
