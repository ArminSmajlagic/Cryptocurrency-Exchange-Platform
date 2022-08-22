using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using servisi.web_api.IServisi.User;

namespace core.web_api.Filteri;
public class AuthorizationFilter : IAuthorizationFilter
{
    private ILogger _logger;
    private IAuthServis authServis;

    public AuthorizationFilter(ILogger logger,IAuthServis authServis)
    {
        _logger = logger;
        this.authServis = authServis;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.ActionDescriptor.DisplayName.Contains("AuthController") && !context.ActionDescriptor.DisplayName.Contains("ValutaController") && !context.ActionDescriptor.DisplayName.Contains("PonudaController"))
        {

            var res = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                res = false;

            string token = string.Empty;
            string role = string.Empty;
            string client = string.Empty;

            if (res)
            {
                token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;


                role = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "role").Value;

                client = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "client").Value;

                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(client))
                {
                    client = "";
                    role = "";
                }


                if (!authServis.verifyToken(token, role, client))
                    res = false;
            }

            if (!res)
            {
                context.ModelState.AddModelError("Unauthroized", "You are not authorized");

                context.Result = new JsonResult(context.ModelState);

    
            }
        }
    }
}

