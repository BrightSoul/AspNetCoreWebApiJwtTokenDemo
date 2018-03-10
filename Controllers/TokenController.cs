using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtTokenDemo.Model.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenDemo.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        // GET api/Token
        [HttpPost]
        public IActionResult GetToken([FromBody] TokenRequest tokenRequest)
        {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            if (!VerifyCredentials(tokenRequest.Username, tokenRequest.Password)) {
                return Unauthorized();
            }

            //L'utente ha fornito credenziali valide
            //creiamo per lui una ClaimsIdentity
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            //Aggiungiamo uno o più claim relativi all'utente loggato
            identity.AddClaim(new Claim(ClaimTypes.Name, tokenRequest.Username));
            //Incapsuliamo l'identità in una ClaimsPrincipal e associamola alla richiesta corrente
            HttpContext.User = new ClaimsPrincipal(identity);

            //Non restituiamo nulla. Il token verrà prodotto dal JwtTokenMiddleware
            return NoContent();
        }

        private bool VerifyCredentials(string username, string password) {
            //Vediamo se le credenziali fornite sono valide
            //TODO: Modificare questa implementazione, che è puramente dimostrativa
            return username == "Admin" && password == "Password";
        }

    }
}
