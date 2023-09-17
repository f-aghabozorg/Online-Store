using Microsoft.AspNetCore.Mvc;


namespace EndPoint.Site.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
