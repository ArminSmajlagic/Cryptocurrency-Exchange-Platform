using database.trading.DB_Models.User.Wallet;
using Microsoft.EntityFrameworkCore;
using modeli.trading.User.Wallet;
using servisi.trading.IRepos.User.Wallet;

namespace servisi.trading.Repos.User.Wallet;

public class WalletServis : IWalletServis
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public WalletServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
        mapper = _mapper;
    }

    public async Task<walletTransakcija> DodajWalletTransakciju(WalletTransakcija transakcija)
    {
        if (transakcija == null)
            return null;


        var set_imovina = Context.wallet_imovine;

        var imovine = set_imovina.First(x=>x.walletId == transakcija.walletId && x.naziv_valute=="WCash");

        var wallet = Context.walleti.FirstOrDefault(x => x.id == imovine.walletId);

        var user = Context.korisnici.FirstOrDefault(x => x.user_id == wallet.userId);

        if (transakcija.tip_transakcije_id == 0)
            imovine.kolicina_valute += transakcija.wcash;      
        else
        {
            if ((imovine.kolicina_valute - transakcija.wcash) < 0)
                return null;
            imovine.kolicina_valute -= transakcija.wcash;
        }

        //set stanje racuna
        //user.stanje = imovine.kolicina_valute;

        await Context.SaveChangesAsync();

        var mapped_transakcija = mapper.Map<walletTransakcija>(transakcija);

        mapped_transakcija.vrijeme_obavljanja = DateTime.Now;

        Context.wallet_transakcije.Add(mapped_transakcija);

        await Context.SaveChangesAsync();

        return mapped_transakcija;

    }



    public async Task<List<WalletTransakcija>> getTransactionData(int wallet_id)
    {
        if (wallet_id < 1)
            return null;

        var set = Context.wallet_transakcije;

        var list = set.Where(x=>x.walletId== wallet_id).ToList();

        return mapper.Map<List<WalletTransakcija>>(list);
    }

    public async Task<modeli.trading.User.Wallet.Wallet> getWalletData(int user_id)
    {
        if (user_id < 1)
            return null;

        var set = Context.walleti;

        var wallet = await set.FirstAsync(x => x.userId == user_id);

        return mapper.Map<modeli.trading.User.Wallet.Wallet>(wallet);
    }

    public async Task<List<WalletImovina>> getCryptoAssets(int wallet_id)
    {
        var set = Context.wallet_imovine;

        var imovina = await set.Where(x=>x.walletId == wallet_id).ToListAsync();

        return mapper.Map<List<WalletImovina>>(imovina);

    }

    public Task<bool> Depozit(int wallet_id, WalletTransakcija transakcija)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Withdraw(int wallet_id, WalletTransakcija transakcija)
    {
        throw new NotImplementedException();
    }
}

