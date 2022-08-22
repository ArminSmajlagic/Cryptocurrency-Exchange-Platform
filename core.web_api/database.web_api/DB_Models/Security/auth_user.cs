using database.trading.DB_Models.User;

namespace database.trading.DB_Models.Security;
[Table("auth_korisnik")]
public class auth_user
{
    [Key]
    public int id { get; set; }
    [MinLength(5)]
    [MaxLength(15)]
    public string username { get; set; }
    [MinLength(5)]
    [MaxLength(15)]
    public string lozinka { get; set; }

    //pregledati vjezbe RS2 gdje se vrši hashing i salting
    public string hash { get; set; }
    public string salt { get; set; }

    //rola - npr. admin,trader...
    public string tip { get; set; }

}
