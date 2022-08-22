using database.trading.DB_Models.User;
using servisi.trading.IRepos.User;
using servisi.trading.Repos.Base;
namespace servisi.trading.Repos.User;
public class UserReadServis : ReadServis<modeli.trading.User.User,user,object>, IUserReadServis
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public UserReadServis(IMapper mapper,DatabaseContext context, IConfiguration _config, ILogger _logger):base(mapper,context,_config,_logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
        this.mapper = mapper;
    }

    public override async Task<IEnumerable<modeli.trading.User.User>> GetAll(object searchParam)
    {
        var set = Context.korisnici;
        var result = new List<modeli.trading.User.User>();
        foreach (var item in set)
        {
            var entity = mapper.Map<modeli.trading.User.User>(item);

            var wallet = Context.walleti.FirstOrDefault(x => x.userId == item.user_id);

            if (wallet != null)
            {
                var imovina = Context.wallet_imovine.FirstOrDefault(x => x.walletId == wallet.id && x.valuta_id == 15);

                if (imovina != null)
                {
                    entity.stanje_walleta = imovina.kolicina_valute;

                    result.Add(entity);
                }
            }
        }
        

        return result;
    }

    public override async Task<modeli.trading.User.User> GetById(int id)
    {
        var set = Context.korisnici;

        var result = set.FirstOrDefault(x => x.user_id == id);

        if (result != null)
        {
            var entity = mapper.Map<modeli.trading.User.User>(result);
         
            var wallet = Context.walleti.FirstOrDefault(x => x.userId == id);

            if (wallet != null)
            {
                var imovina = Context.wallet_imovine.FirstOrDefault(x => x.walletId == wallet.id && x.valuta_id == 15);

                if(imovina != null)
                {
                    entity.stanje_walleta = imovina.kolicina_valute;

                    return entity;
                }
            }
        }

        return null;
    }
    //public override async Task<modeli.trading.User.User> GetById(int id)
    //{
    //    if (id < 1)
    //        return null;

    //    var set = Context.korisnici;

    //    var lista = set.ToList();

    //    var entity = await set.FindAsync(id);

    //    if (entity == null)
    //        return null;

    //    var mappedEntity = mapper.Map<modeli.trading.User.User>(entity);

    //    return mappedEntity;
    //} include auth user while geting user


}
