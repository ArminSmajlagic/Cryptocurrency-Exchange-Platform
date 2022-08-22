using core.web_api.Controllers.Base;
using database.trading.DB_Models.SearchObjects;
using database.trading.DB_Models.Trading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.Trading;
using modeli.trading.Trading.Requests;
using servisi.trading.IRepos.Base;
using servisi.trading.IRepos.Trading;

namespace core.web_api.Controllers.Trading
{
    [Route("[controller]")]
    [ApiController]
    public class NarudzbaController : ReadWriteController<Narudzba, narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest>
    {
        private readonly INarudzbaServis narudzbaServis;

        public NarudzbaController(IHttpContextAccessor contextAccessor, INarudzbaServis narudzbaServis) : base(contextAccessor, narudzbaServis)
        {
            this.narudzbaServis = narudzbaServis;
        }

        [HttpPut("{id}/Aktiviraj")]
        public async Task<IActionResult> Aktiviraj(int id)
        {
            var result = false;

            if(id > 0)
                result = await narudzbaServis.aktiviraj(id);

            return Ok(result?"Uspješno aktivirana!":"Nešto nije bilo uredu!");
        }

        [HttpGet("Odbij/{id}")]
        public async Task<IActionResult> Odbij(int id)
        {
            var result = false;

            if (id > 0)
                result = await narudzbaServis.odbij(id);

            var respons = result ? 1 : 0;
            return Ok(respons);
        }

        [HttpPut("{id}/Terminiraj")]
        public async Task<IActionResult> Terminiraj(int id)
        {
            var result = false;

            if (id > 0)
                result = await narudzbaServis.terminiraj(id);

            return Ok(result ? "Uspješno terminirana!" : "Nešto nije bilo uredu!");
        }

        [HttpGet("Forms/{id?}")]
        public async Task<IActionResult> GetAllForms(int id=0)
        {
            var result = await narudzbaServis.GetAllForms(id);
            return Ok(result);
        }

    }
}
