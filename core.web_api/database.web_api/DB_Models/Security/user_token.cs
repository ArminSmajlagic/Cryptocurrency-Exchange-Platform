namespace database.trading.DB_Models.Security;
public class user_token
{
    [Key]
    public int user_token_id { get; set; }

    [ForeignKey("user_id")]
    public int user_id { get; set; }

    [ForeignKey("token_id")]
    public int token_id { get; set; }
    public DateTime time { get; set; }
}

