using servisi.trading.IRepos.User;

namespace servisi.trading.Repos.User;
public class UserTradeServis<T>: IUserTradeServis<T>
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public UserTradeServis(IMapper mapper, DatabaseContext context, IConfiguration _config, ILogger _logger)//:base(mapper, context, _config, _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
    }

    public Task<T> Buy(object nesto)
    {
        throw new NotImplementedException();
    }

    public Task<T> Sell(object nesto)
    {
        throw new NotImplementedException();
    }

}

