using modeli.trading.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using servisi.trading.Configuration;

namespace servisi.trading.Repos.Security;
public class TokenManager
{

    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public TokenManager(DatabaseContext context, IConfiguration _config, ILogger _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
    }


    public static Token CreateToken(int user_id,string rola)
    {

        //check roles, claims then provide necessary scopes
        //store token user_id pair in database

        var scopes = new List<string>();

        if (rola == "Admin")
            scopes.AddRange(new[]
            {
                "trading_api.read",
                "trading_api.write",
                "trading_api.admin"
            });
        else if (rola == "Trader")
            scopes.AddRange(new[]
            {
                "trading_api.read",
                "trading_api.write",
                "trading_api.trade"
            });

        var claims = new[]
        {
                new Claim("user id",user_id.ToString()),
                new Claim("role",rola),
                new Claim("scope1",scopes[0]),
                new Claim("scope2",scopes[1]),
                new Claim("scope3",scopes[2]),

        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This_is_the_hidden_token_key"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            Constants.issuer, 
            Constants.mobile_audience, 
            claims, 
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddMinutes(30)
            );

        var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

        var mojToken = new Token()
        {
            error = "x",
            issued = DateTime.Now,
            expires = DateTime.Now.AddMinutes(30),
            user_id = user_id,
            value = tokenJson,
            allowed_scopes = scopes
        };


        return mojToken;
    }

    

    public static int UkloniToken(int id)
    {

        return 0;
    }

}

