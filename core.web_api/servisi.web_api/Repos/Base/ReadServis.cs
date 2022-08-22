using servisi.trading.IRepos.Base;

namespace servisi.trading.Repos.Base;
public class ReadServis<T, Tdb, TSearch> : IReadServis<T,Tdb,TSearch> where T : class where Tdb : class where TSearch : class
{
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    private readonly IMapper mapper;

    public ReadServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
        mapper = _mapper;
    }

    public virtual async Task<IEnumerable<T>> GetAll(TSearch searchParam)
    {
        //override in case of searching

        var set =  Context.Set<Tdb>();

        var lista = set.ToList();

        return mapper.Map<List<T>>(lista);
    }

    public virtual async Task<T> GetById(int id)
    {
        if (id < 1)
            return null;

        var set = Context.Set<Tdb>();

        var lista = set.ToList();

        var entity = await set.FindAsync(id);

        if (entity == null)
            return null;

        var mappedEntity =  mapper.Map<T>(entity);

        return mappedEntity;
    }
}

