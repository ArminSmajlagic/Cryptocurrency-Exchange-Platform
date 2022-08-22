using core.web_api.Controllers.Base;
using database.trading.DB_Models.Kripto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.Kripto;
using servisi.trading.IRepos.Base;
namespace core.web_api.Controllers.Kripto;
[Route("[controller]")]
[ApiController]
public class PonudaController : ReadController<Ponuda, ponuda, object>
{
    public PonudaController(IHttpContextAccessor contextAccessor, IReadServis<Ponuda, ponuda, object> readServis) : base(contextAccessor, readServis)
    {

    }

    [HttpPost]
    public virtual async Task<IActionResult> DodajValutuUPonudu(int ponuda,int valuta)
    {
        throw new NotImplementedException();

        return Ok();
    }
}

