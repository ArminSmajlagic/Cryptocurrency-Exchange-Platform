using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servisi.trading.IRepos.Base;
using servisi.trading.Repos.Base;
namespace core.web_api.Controllers.Base;

[Route("[controller]")]
[ApiController]
public class ReadController<T, Tdb, TSearch> : ControllerBase where T : class where Tdb : class where TSearch : class 
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IReadServis<T, Tdb, TSearch> _readServis;


    public ReadController(IHttpContextAccessor contextAccessor, IReadServis<T, Tdb, TSearch> readServis)
    {
        _contextAccessor = contextAccessor;
        _readServis = readServis;
    }

    [HttpGet]//example of good practice [HttpGet, Route("/getall")]
    public virtual async Task<IActionResult> GetAll([FromQuery]TSearch searchParam)
    {

        var enumerable = await _readServis.GetAll(searchParam);

        if (enumerable == null)
            return BadRequest();

        //return NotFound(); is a good practice if TSearch is not found - requries modification of service

        return Ok(enumerable);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(int id)
    {

        if (id == 0 || id < 0)
            return BadRequest("ID koji ste proslijedili nije validan.");

        var entity = await _readServis.GetById(id);

        if(entity==null)
            return NotFound("Entity "+typeof(T).ToString() +" sa datim id-om nije pronađen.");


        return Ok(entity);
    }

}

