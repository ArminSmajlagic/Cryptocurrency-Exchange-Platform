
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using modeli.trading.Security;
using modeli.trading.Security.Request;
using modeli.trading.Security.Requests;
using servisi.web_api.IServisi.User;

using System.Text;

namespace core.web_api.Controllers.OAuth
{
    [Route("auth_api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServis authServis;

        public AuthController(IAuthServis authServis)
        {
            this.authServis = authServis;
        }

        //[ValidateAntiForgeryToken]
        [HttpPost, Route("Login")]
        public async Task<ActionResult<Token>> Login([FromBody] LoginRequest req)
        {
            if (ReferenceEquals(req, null))
                return BadRequest("Request data is not valid!");

            var token =await authServis.Login(req);

            return Ok(token);
        }


        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            if (ReferenceEquals(req, null))
                return BadRequest("Request data is not valid!");

            var token = await authServis.Register(req);

                return Ok(token);
        }

        [HttpPost("Logout/{id}")]
        public async Task<ActionResult<string>> Logout(int id)
        {
            //validation has to be performed here

            var result = await authServis.Logout(id);

            return Ok(result);
        }


        [HttpPost("Privacy/Update/{id}")]
        public async Task<ActionResult<string>> UpdateCredentials(int id,string pwd = "", string username = "", string password = "")
        {
            //validation has to be performed here
            var result = await authServis.UpdateCredentials(id,pwd, username, password);

            return Ok(result);
        }

        [HttpPost, Route("Verify/Email")]
        public async Task<IActionResult> Verify([FromBody]ConfirmationRequest req)
        {
            if (string.IsNullOrEmpty(req.code) || req.user_id < 1)
                return BadRequest("Kod ili user_id nije validan.");

            var result = await authServis.VerifyUserByEmail(req.user_id, req.code);

            return Ok(result);
        }

        //[HttpPost, Route("Verify/SMS")]
        //public async Task<ActionResult<string>> VerifySMS(int user_id,string code)
        //{
        //    //validation has to be performed here

        //    var result = authServis.VerifyUserBySMS(user_id, code);

        //    return Ok(result);
        //}

        //research return urls

        [HttpGet,Route("GetToken")]
        public IActionResult Token(int user_id, string scope)
        {
            var token = authServis.GetToken(user_id, scope);

            return Ok(token);
        }

    }



}
