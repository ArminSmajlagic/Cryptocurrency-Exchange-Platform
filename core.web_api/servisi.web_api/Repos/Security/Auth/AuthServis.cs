using database.trading.DB_Models.Security;
using modeli.trading.Security;
using modeli.trading.Security.Request;
using servisi.trading.EmailConfiguration;
using servisi.trading.IRepos.Mail;
using servisi.trading.IRepos.User;
using servisi.trading.Repos;
using servisi.trading.Repos.Security;
using servisi.trading.Repos.Security.Verification;
using servisi.web_api.IServisi.User;
using System.IdentityModel.Tokens.Jwt;

namespace servisi.web_api.Servisi.Security.Auth;

public class AuthServis : IAuthServis
{
    private readonly IConfiguration config;
    private readonly LoggerServis logger;
    private readonly IUserWriteServis userWriteServis;
    private readonly IEmailService mailServis;
    private readonly SimpleCodeGenerator codeGenerator;
    private readonly DatabaseContext Context;
    private readonly IMapper mapper;
    public AuthServis(IMapper _mapper,DatabaseContext context, IConfiguration _config, LoggerServis _logger, IUserWriteServis userWriteServis, IEmailService mailServis,SimpleCodeGenerator codeGenerator)
    {
        Context = context;
        config = _config;
        logger = _logger;
        this.userWriteServis = userWriteServis;
        this.mailServis = mailServis;
        this.codeGenerator = codeGenerator;
        mapper = _mapper;
    }

    public async Task<string> VerifyUserByEmail(int user_id, string code)
    {

        var set = Context.user_confirmacije;

        var mail = set.FirstOrDefault(x=>x.userId==user_id);

        if (mail == null)
            return "User nije pronađen.";

        if (mail.code == code)
        {
            mail.confirmed = true;

            await Context.SaveChangesAsync();

            return "Uspješno ste potvrdili vaš mail!";
        }

        return "Kod koji ste proslijedili nije validan.";
           

    }

    public Task<string> VerifyUserBySMS(int user_id, string code)
    {
        throw new NotImplementedException();
    }

    public async Task<Token> Login(LoginRequest request)
    {
        if (request == null)
            return new Token() { error = "Zahtjev koji ste poslali nije validan." };

        if(string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.lozinka))
            return new Token() { error="Korisnicko ime ili lozinka nisu validni | null or empty."};

        var set_auth_korisnika = Context.auth_korisnici;

        var set_korisnika = Context.korisnici;

        var auth_user = set_auth_korisnika.FirstOrDefault(x => x.username == request.username && x.lozinka == request.lozinka);

        if(auth_user == null)
            return new Token() { error = "Korisnicko ime ili lozinka nisu validni. Provjerite vaš unos i probajte ponovo." };

        var user = set_korisnika.FirstOrDefault(x => x.authUserId == auth_user.id);

        var token = TokenManager.CreateToken(user.user_id, auth_user.tip);

        var mappedToken = mapper.Map<token>(token);

        mappedToken.expired = false;

        mappedToken.valid = true;

        mappedToken.userId = user.user_id;

        var entity = Context.tokeni.Add(mappedToken);

        await Context.SaveChangesAsync();

        //case that takes in considiration possibility that there is already a token that has not expired in the database
        //in that case user as well should not need to login again (save user_id in local storage, then send it to API for check)

        return token;
    }

    public async Task<string> Logout(int user_id)
    {
        var set_tokena = Context.tokeni;

        var token = set_tokena.FirstOrDefault(x=>!x.expired && x.userId==user_id);

        if (token == null)
            return "Korisnik nije uspješno odjlavljen.";

        token.valid = false;

        await Context.SaveChangesAsync();

        return "Korisnik je uspješno odjlavljen.";
    }

    public async Task<Token> Register(RegisterRequest request)
    {
        if (request == null)
            return new Token() { error = "Zahtjev koji ste poslali nije validan." };


        var entity = await userWriteServis.Insert(new modeli.trading.User.Request.UserUpsertRequest() {
            //unos propertiya iz rr requesta
            broj_telefona = request.broj_telefona,
            drzava = request.drzava,
            ime_prezime = request.ime_prezime,
            username = request.username,
            lozinka = request.lozinka,
            email = request.email,
            spol = request.spol
        });



        var code = SimpleCodeGenerator.getRandomCode();

        //here goes logic to send email

        var mail = new Mail(request.email, "Dobrodošli u kript trejding!", "Vaš kod je :" + code + " .\nAko ovo niste vi možete ga ignorisati.", request.ime_prezime);

        try
        {

            mailServis.SendEmail(mail);

        }
        catch (Exception ex)
        {

            return new Token() { error = ex.Message };

        }

        await Context.user_confirmacije.AddAsync(new user_confirmation() { 
            code = code,
            timeStamp = DateTime.Now,
            userId = entity.user_id,
            confirmed = false,
        });

        await Context.SaveChangesAsync();

        var token = TokenManager.CreateToken(entity.user_id, "Trader");

        var mappedToken = mapper.Map<token>(token);

        mappedToken.expired = false;

        mappedToken.valid = true;

        mappedToken.userId = entity.user_id;

        Context.tokeni.Add(mappedToken);

        await Context.SaveChangesAsync();

        return token;
    }

    public async Task<auth_user> UpdateCredentials(int user_id,string pwd = "", string username = "", string password = "")
    {
        var set = Context.korisnici;

        var set_auth_usera = Context.auth_korisnici;

        var korisnik = set.FirstOrDefault(x => x.user_id == user_id);

        var auth_korinsik = set_auth_usera.FirstOrDefault(x=>x.id == korisnik.authUserId);

        if (string.IsNullOrEmpty(pwd))
            return null;

        var auth_user = auth_korinsik.lozinka == pwd ? auth_korinsik : null;

        if (auth_user == null)
            return null;

        if (!string.IsNullOrEmpty(username))
            auth_user.username = username;

        if (!string.IsNullOrEmpty(password))
            auth_user.lozinka = password;

        await Context.SaveChangesAsync();

        return auth_user;
    }


    public Token GetToken(int user_id,string scope)
    {
        return TokenManager.CreateToken(user_id, scope);
    }



    public bool verifyToken(string token, string Role, string Client)
    {
        if (Role == "")
        {
            Role = "admin";
            Client = "desktop";

        }
        //remove keyword Bearer from token
        token = token.Remove(0,7); 

        //decrypt token
        var handler = new JwtSecurityTokenHandler();
        var tokenData = handler.ReadJwtToken(token);
        var jwtSecurityToken = tokenData.Payload;

        //get claims from token
        var claims = jwtSecurityToken.Claims;

        var user_id = claims.First(x => x.Type == "user id").Value;
        var role = claims.First(x => x.Type == "role").Value;

        //check token validity
        var dbToken = Context.tokeni.Where(x=>x.value==token && x.userId.ToString() == user_id).OrderByDescending(x=>x.token_id).Last();

        var user = Context.korisnici.Find(dbToken.userId);

        var authUser = Context.auth_korisnici.Find(user.authUserId);

        if (dbToken.expires < DateTime.Now)
        {
            return false;

            dbToken.valid = false;

            Context.SaveChangesAsync();
        }

        //check role
        if (role.ToLower() != Role.ToLower())
            return false;

        if (role.ToLower() != authUser.tip.ToLower())
            return false;

        //check client && role
        if (Client.ToLower() == "mobile" && role.ToLower() == "admin")
            return false;

        return true;
    }
}

