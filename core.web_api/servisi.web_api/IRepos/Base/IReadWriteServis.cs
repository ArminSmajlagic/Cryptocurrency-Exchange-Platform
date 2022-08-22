namespace servisi.trading.IRepos.Base;
public interface IReadWriteServis<T,Tdb,TSearch,TUpsert> : IReadServis<T, Tdb, TSearch>
{
    Task<Tdb> Insert(TUpsert requestBody);
    Task<TUpsert> Update(int id, TUpsert requestBody);
    Task<T> Delete(int id); 
}

