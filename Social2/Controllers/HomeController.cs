using Microsoft.AspNetCore.Mvc;

namespace Social2.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Models.SquareResult result = new Models.SquareResult();

            string input = Request.Query["input"];
            int inputAsInt = int.Parse(input);
            int inputSquared = inputAsInt * inputAsInt;

            result.SetVal(inputSquared);
            return View(result);
        }
    }
}
