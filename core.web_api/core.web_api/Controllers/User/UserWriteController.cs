using core.web_api.Controllers.Base;
using database.trading.DB_Models.User;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.User;
using modeli.trading.User.Request;
using servisi.trading.IRepos.Base;
using servisi.trading.IRepos.User;
using servisi.trading.Repos.Base;
using servisi.trading.Repos.User;

namespace core.web_api.Controllers.User;
[Route("main_vi_api/[controller]")]
[ApiController]
public class UserWriteController : WriteController<modeli.trading.User.User, user,UserUpsertRequest>
{
    public UserWriteController(IHttpContextAccessor contextAccessor, IUserWriteServis writeServis) : base(contextAccessor, writeServis)
    {

    }

}

