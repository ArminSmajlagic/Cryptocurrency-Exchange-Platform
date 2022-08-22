using core.web_api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using servisi.trading.Repos.Base;
using servisi.trading.Repos.User;
using modeli.trading.User;
using servisi.trading.IRepos.Base;
using database.trading.DB_Models.User;
using servisi.trading.IRepos.User;

namespace core.web_api.Controllers.User;

[Route("user")]
[ApiController]
public class UserReadController : ReadController<modeli.trading.User.User,user,object>
{
    public UserReadController(IHttpContextAccessor contextAccessor, IUserReadServis readServis):base(contextAccessor,readServis)
    {

    }
}

