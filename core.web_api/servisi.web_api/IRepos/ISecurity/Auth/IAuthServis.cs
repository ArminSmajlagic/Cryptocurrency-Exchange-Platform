using database.trading.DB_Models.Security;
using modeli.trading.Security;
using modeli.trading.Security.Request;
using modeli.trading.User;

namespace servisi.web_api.IServisi.User;

public interface IAuthServis
{
    Task<Token> Login(LoginRequest request);
    Token GetToken(int user_id, string code);
    Task<Token> Register(RegisterRequest request);
    Task<string> Logout(int user_id);
    bool verifyToken(string token, string Role, string Client);
    Task<string> VerifyUserBySMS(int user_id, string code);
    Task<string> VerifyUserByEmail(int user_id, string code);
    Task<auth_user> UpdateCredentials(int user_id,string pwd = "", string username = "", string password = "");
}

