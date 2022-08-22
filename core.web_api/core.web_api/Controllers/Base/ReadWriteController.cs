using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servisi.trading.IRepos.Base;

namespace core.web_api.Controllers.Base;
[Route("[controller]")]
[ApiController]
public class ReadWriteController<T, Tdb,TSearch, TUpsert> : ReadController<T,Tdb,TSearch> where T : class where Tdb : class where TSearch : class where TUpsert : class
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IReadWriteServis<T, Tdb, TSearch, TUpsert> readWriteServis;

    public ReadWriteController(IHttpContextAccessor contextAccessor, IReadWriteServis<T, Tdb, TSearch, TUpsert> readWriteServis) :base(contextAccessor, readWriteServis)
    {
        _contextAccessor = contextAccessor;
        this.readWriteServis = readWriteServis;
    }

    [HttpPost]
    public async Task<ActionResult<T>> Insert([FromBody] TUpsert entity)
    {
        var respons = await readWriteServis.Insert(entity);

        if (ReferenceEquals(respons, null))
            return Ok("Korisnik nema dovoljno valute da je proda ili nema dovoljno WCasha da je kupi!");

        if (entity == null)
            return BadRequest("Entity was not valid!");

        return Ok(respons);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<T>> Update(int id, [FromBody] TUpsert entity)
    {
        var respons = await readWriteServis.Update(id, entity);

        if (ReferenceEquals(respons, null))
            return Ok("Korisnik nema dovoljno valute da je proda ili nema dovoljno WCasha da je kupi!");

        if (entity == null)
            return BadRequest("Entity was not valid!");

        return Ok(respons);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<T>> Delete(int id)
    {
        var respons = await readWriteServis.Delete(id);

        if (id < 1 || ReferenceEquals(respons, null))
            return BadRequest("id was not valid!");

        return Ok(respons);
    }
}

