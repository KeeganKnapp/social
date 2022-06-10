using Microsoft.AspNetCore.Mvc;

namespace Social2.Controllers
{
    public class HomeController : Controller
    {
        private static List<User> users = new List<User>();
        public ViewResult Index()
        {
            if (Request.Method.ToUpper() == "POST")
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                User user = new User();
                user.UserName = username;
                user.Password = password;
                int maxId = -1;
                foreach (var existinguser in users)
                {
                    if(existinguser.Id > maxId)
                    {
                        maxId = existinguser.Id;
                    }
                }
                user.Id = maxId + 1;
                users.Add(user);
            }
     
            return View();

        }

        public ViewResult Users()
        {
            
            return View(users);
        }
    }
}
