using database.trading.DB_Models.Kripto;
using modeli.trading.Kripto;
using servisi.trading.IRepos.Kripto;
using servisi.trading.Repos.Base;

namespace servisi.trading.Repos.Kripto;
public class PonudeServis:ReadServis<Ponuda, ponuda,object>,IPonudeServis
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public PonudeServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger) : base(_mapper, context, _config, _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
        mapper = _mapper;

    }
}

