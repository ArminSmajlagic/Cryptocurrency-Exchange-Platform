using database.trading.DB_Models.Security;
using database.trading.DB_Models.User;
using modeli.trading.User.Request;
using servisi.trading.IRepos.User;
using servisi.trading.Repos.Base;

namespace servisi.trading.Repos.User;
public class UserWriteServis : WriteServis<modeli.trading.User.User, user, UserUpsertRequest>,IUserWriteServis
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public UserWriteServis(IMapper mapper, DatabaseContext context, IConfiguration _config, ILogger _logger):base(mapper, context, _config, _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
    }

    public override async Task<UserUpsertRequest> Update(int id, UserUpsertRequest requestBody)
    {

        var set = Context.Set<user>();

        var set_entity =await set.FindAsync(id);

        if (set_entity == null)
            return null;

        if(!string.IsNullOrEmpty(requestBody.drzava))
            set_entity.drzava = requestBody.drzava;

        if (!string.IsNullOrEmpty(requestBody.broj_telefona))
            set_entity.broj_telefona = requestBody.broj_telefona;

        if (!string.IsNullOrEmpty(requestBody.email))
            set_entity.email = requestBody.email;

        if (!string.IsNullOrEmpty(requestBody.ime_prezime))
            set_entity.ime_prezime = requestBody.ime_prezime;

        if (requestBody.datum_kreiranja.ToShortDateString != DateTime.Now.ToShortDateString)
            set_entity.datum_kreiranja = requestBody.datum_kreiranja;

        await Context.SaveChangesAsync();

        return requestBody;
    }

    public override async Task<user> Insert(UserUpsertRequest requestBody)
    {

        var auth_korisnik = new auth_user();

        auth_korisnik.lozinka = requestBody.lozinka;

        auth_korisnik.username = requestBody.username;

        auth_korisnik.tip = "Trader";

        //potrebna implementqacija za hash i salt

        auth_korisnik.hash = "yet not implemented";

        auth_korisnik.salt = "yet not implemented";

        var respons = Context.auth_korisnici.Add(auth_korisnik);

        await Context.SaveChangesAsync();

        requestBody.authUserId = respons.Entity.id;

        var entity = await base.Insert(requestBody);

        if (entity == null)
            return null;

        await Context.SaveChangesAsync();


        var wallet = await Context.walleti.AddAsync(new database.trading.DB_Models.User.Wallet.wallet() { 
            userId=entity.user_id      
        });

        await Context.SaveChangesAsync();

        var setImovina = Context.wallet_imovine;

        

        await setImovina.AddAsync(new database.trading.DB_Models.User.Wallet.wallet_imovina() { 
            naziv_valute="WCash",
            walletId = wallet.Entity.id,
            kolicina_valute = 0,
            valuta_id = 15
        });

        await Context.SaveChangesAsync();



        return entity;
    }


}
