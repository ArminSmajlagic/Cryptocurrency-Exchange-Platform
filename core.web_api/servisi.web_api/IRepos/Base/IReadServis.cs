namespace servisi.trading.IRepos.Base;
public interface IReadServis<T,Tdb,TSearch>
{
    Task<IEnumerable<T>> GetAll(TSearch searchParam);
    Task<T> GetById(int id);
}

