using servisi.trading.IRepos.Base;

namespace servisi.trading.Repos.Base;
public class ReadWriteBaseServis<T, Tdb, TSearch, TUpsert>: ReadServis<T, Tdb, TSearch>, IReadWriteServis<T, Tdb, TSearch, TUpsert> where T : class where Tdb : class where TUpsert : class where TSearch : class
{
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    private readonly IMapper mapper;

    public ReadWriteBaseServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger) : base(_mapper, context, _config, _logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
        mapper = _mapper;

    }

    public virtual async Task<T> Delete(int id)
    {
        if (id == 0)
            return null;

        var set = Context.Set<Tdb>();

        var lista = set.ToList();

        var entity = await set.FindAsync(id);

        if (entity == null)
            return null;

        set.Remove(entity);

        await Context.SaveChangesAsync();

        return mapper.Map<T>(entity);
    }

    public virtual async Task<Tdb> Insert(TUpsert requestBody)
    {
        if (requestBody == null)
            return null;

        var set = Context.Set<Tdb>();

        var lista = set.ToList();

        Tdb entityMapped = mapper.Map<Tdb>(requestBody);

        if (entityMapped == null)
            return null;

        //var entity = await set.FindAsync(entityMapped);

        //if (entity == null)
        //    return null;

        var entity = await set.AddAsync(entityMapped);

        await Context.SaveChangesAsync();

        return entity.Entity;
    }

    public virtual async Task<TUpsert> Update(int id, TUpsert requestBody)
    {
        var set = Context.Set<Tdb>();

        Tdb entity = mapper.Map<Tdb>(requestBody);

        //do an operation on object
        throw new Exception("Object can't be updated well in generic servis! Internal error!");

        // there is this, I dont know does this change it mapper.Map(requestBody, entity);

        await Context.SaveChangesAsync();

        return requestBody;
    }

}

