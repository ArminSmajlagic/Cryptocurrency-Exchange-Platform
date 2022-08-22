using core.web_api.Controllers.Base;
using database.trading.DB_Models.Kripto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.Kripto;
using servisi.trading.IRepos.Base;
using servisi.trading.IRepos.Kripto;

namespace core.web_api.Controllers.Kripto
{
    [Route("[controller]")]
    [ApiController]
    public class ValutaController : ReadController<Valuta, valuta, object>
    {
        private readonly IValuteServis valutaServis;

        public ValutaController(IHttpContextAccessor contextAccessor,IValuteServis valutaServis, IReadServis<Valuta,valuta,object> readServis) : base(contextAccessor, readServis)
        {
            this.valutaServis = valutaServis;
        }

        [HttpGet("{id}/history")]
        public List<historijskiPodaci> GetHistorijskiPodaci(int id)
        {
            var list = valutaServis.GetHistorijskiPodaci(id);

            return list;
        }

        [HttpGet("{id}/Stats")]//example of good practice [HttpGet, Route("/getall")]
        public async Task<IActionResult> GetValutaStats(int id)
        {
            if (id < 1)
                return BadRequest("User id is not valid!");

            var report = valutaServis.GetKriptoReport(id);

            if (report == null)
                return BadRequest();

            //return NotFound(); is a good practice if TSearch is not found - requries modification of service

            return Ok(report);
        }

        [HttpGet("CBF/{id}")]
        public ActionResult<List<Valuta>> GetCBFValute(int id)
        {
            return valutaServis.GetCBFValute(id);
        }
    }
}
