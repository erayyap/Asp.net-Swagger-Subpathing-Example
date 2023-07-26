using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Filters_Example.Controllers
{
    public class BController : Controller
    {
        [HttpGet]
        [Route("B/Method1")]
        public IActionResult Method1()
        {
            return Content("Output 3");
        }

        [HttpGet]
        [Route("B/Method2")]
        public IActionResult Method2()
        {
            return Content("Output 4");
        }
    }
}
