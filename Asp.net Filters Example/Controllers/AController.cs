using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Filters_Example.Controllers
{
    public class AController : Controller
    {
        [HttpGet]
        [Route("A/Method1")]
        public IActionResult Method1()
        {
            return Content("Output 1");
        }

        [HttpGet]
        [Route("A/Method2")]
        public IActionResult Method2()
        {
            return Content("Output 2");
        }
    }
}
