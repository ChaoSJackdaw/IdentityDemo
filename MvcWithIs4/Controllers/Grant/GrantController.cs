using Microsoft.AspNetCore.Mvc;

namespace MvcWithIs4.Controllers.Grant
{
    public class GrantController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GrantsViewModel site, string button)
        {

            return Redirect("~/Home");
        }
    }
}
