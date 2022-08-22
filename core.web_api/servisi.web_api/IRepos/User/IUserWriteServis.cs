using database.trading.DB_Models.User;
using modeli.trading.User.Request;
using servisi.trading.IRepos.Base;

namespace servisi.trading.IRepos.User;
public interface IUserWriteServis : IWriteServis<modeli.trading.User.User, user, UserUpsertRequest>
{
}

