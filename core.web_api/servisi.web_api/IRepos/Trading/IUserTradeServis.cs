namespace servisi.trading.IRepos.User;
public interface IUserTradeServis<T>
{
    Task<T> Buy(object nesto);
    Task<T> Sell(object nesto);

}

