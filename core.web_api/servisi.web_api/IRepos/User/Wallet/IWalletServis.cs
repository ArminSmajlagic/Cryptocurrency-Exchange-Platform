using database.trading.DB_Models.User.Wallet;
using modeli.trading.User.Wallet;

namespace servisi.trading.IRepos.User.Wallet;
public interface IWalletServis
{
    Task<walletTransakcija> DodajWalletTransakciju(WalletTransakcija transakcija);  
    Task<modeli.trading.User.Wallet.Wallet> getWalletData(int wallet_id);
    Task<List<WalletImovina>> getCryptoAssets(int user_id);
    Task<List<WalletTransakcija>> getTransactionData(int wallet_id);
    Task<bool> Depozit(int wallet_id,WalletTransakcija transakcija);
    Task<bool> Withdraw(int wallet_id, WalletTransakcija transakcija);
}

