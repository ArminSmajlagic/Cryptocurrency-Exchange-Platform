using database.trading.DB_Models.User;
using modeli.trading.Security;

namespace database.trading.DB_Models.Security;
public class token
{
    [Key]
    public int token_id { get; set; }
    public string value { get; set; }
    public DateTime issued { get; set; }
    public DateTime expires { get; set; }
    public bool expired { get; set; }
    public bool valid { get; set; }
    public int userId { get; set; }
    public user user { get; set; }
}

