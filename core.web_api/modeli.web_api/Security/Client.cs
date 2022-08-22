namespace modeli.trading.Security;
public class Client
{
    public string id { get; set; }
    public string name { get; set; }
    public string hidden_secret { get; set; }
    public string redirect_login_uri { get; set; }
    public string redirect_register_uri { get;set; } 
    public string logout_uri { get;set; } 
    public List<string> allows_scopes { get;set; } 
}

