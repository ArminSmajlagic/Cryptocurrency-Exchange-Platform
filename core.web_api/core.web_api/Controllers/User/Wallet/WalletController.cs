using AutoMapper;
using database.trading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modeli.trading.User.Wallet;
using servisi.trading.IRepos.User.Wallet;

namespace core.web_api.Controllers.User.Wallet
{
    [Route("[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DatabaseContext context;
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private readonly IWalletServis walletServis;

        public WalletController(IHttpContextAccessor contextAccessor, IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger,IWalletServis walletServis)
        {
            mapper = _mapper;
            this.context = context;
            config = _config;
            logger = _logger;
            this.walletServis = walletServis;
        }

        [HttpGet("{id_wallet}/getTransactionData")]
        public async Task<IActionResult> getTransactionData(int id_wallet)
        {
            if (id_wallet < 1)
                return BadRequest("Id nije validan");

            var result = await walletServis.getTransactionData(id_wallet);

            return Ok(result);
        }

        [HttpGet("{user_id}/getWalletData")]
        public async Task<IActionResult> getWalletData(int user_id)
        {
            if (user_id < 1)
                return BadRequest("Id nije validan");

            var result = await walletServis.getWalletData(user_id);

            return Ok(result);
        }

        [HttpPost("DodajWalletTransakciju")]
        public async Task<IActionResult> DodajWalletTransakciju([FromBody]WalletTransakcija transakcija)
        {
            //bellow code is copy of getWalletData

            if (transakcija == null)
                return BadRequest("Objekat je null");

            var result = await walletServis.DodajWalletTransakciju(transakcija);

            return Ok(result);
        }


        [HttpGet("{id_wallet}/GetCryptoAssets")]
        public async Task<IActionResult> GetCryptoAssets(int id_wallet)
        {
            //bellow code is copy of getWalletData

            if (id_wallet < 1)
                return BadRequest("Id nije validan");

            var result = await walletServis.getCryptoAssets(id_wallet);

            return Ok(result);
        }


        [HttpPatch("/Depozit/{id_wallet}")]
        public async Task<IActionResult> Depozit(int id_wallet,[FromBody]WalletTransakcija transakcija)
        {
            //bellow code is copy of getWalletData

            if (id_wallet < 1)
                return BadRequest("Id nije validan");

            var result = await walletServis.Depozit(id_wallet, transakcija);

            return Ok(result);
        }


        [HttpPatch("/Withdraw/{id_wallet}")]
        public async Task<IActionResult> Withdraw(int id_wallet, [FromBody] WalletTransakcija transakcija)
        {
            //bellow code is copy of getWalletData

            if (id_wallet < 1)
                return BadRequest("Id nije validan");

            var result = await walletServis.Withdraw(id_wallet, transakcija);

            return Ok(result);
        }
    }
}
