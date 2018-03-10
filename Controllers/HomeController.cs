using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JwtTokenDemo.Controllers
{
    [Route("/")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get() {
            //Ridirezione alla documentazione Swagger
            return Redirect("~/swagger");
        }
    }
}