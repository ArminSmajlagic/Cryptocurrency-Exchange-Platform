using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servisi.trading.IRepos.Base;

namespace core.web_api.Controllers.Base;

[Route("[controller]")]
[ApiController]
public class WriteController<T, Tdb, TUpsert> : ControllerBase where T : class where Tdb : class where TUpsert : class
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IWriteServis<T, Tdb, TUpsert>  _writeServis;

    public WriteController(IHttpContextAccessor contextAccessor,IWriteServis<T, Tdb, TUpsert> writeServis)
    {
        _contextAccessor = contextAccessor;
        _writeServis = writeServis;
    }

    [HttpPost]
    public async Task<ActionResult<T>> Insert([FromBody] TUpsert entity)
    {
        var respons = await _writeServis.Insert(entity);

        if(ReferenceEquals(respons, null) || entity==null)
            return BadRequest("Entity was not valid!");

        return Ok(respons);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<T>> Update(int id, [FromBody] TUpsert entity)
    {
        var respons = await _writeServis.Update(id,entity);

        if (ReferenceEquals(respons, null) || entity == null)
            return BadRequest("Entity was not valid!");

        return Ok(respons);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<T>> Delete(int id)
    {
        var respons = await _writeServis.Delete(id);

        if (id<1 || ReferenceEquals(respons, null))
            return BadRequest("id was not valid!");

        return Ok(respons);
    }
}

