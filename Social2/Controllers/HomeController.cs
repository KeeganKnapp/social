using Microsoft.AspNetCore.Mvc;

namespace Social2.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
