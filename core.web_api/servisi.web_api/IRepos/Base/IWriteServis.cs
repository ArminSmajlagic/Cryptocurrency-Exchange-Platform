namespace servisi.trading.IRepos.Base;
public interface IWriteServis<T,Tdb,TUpsert> where TUpsert : class
{
    Task<Tdb> Insert(TUpsert requestBody);
    Task<TUpsert> Update(int id, TUpsert requestBody);
    Task<T> Delete(int id);
}

