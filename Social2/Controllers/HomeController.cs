using Microsoft.AspNetCore.Mvc;

namespace Social2.Controllers
{
    public class HomeController : Controller
    {
        private static List<User> users = new List<User>();
        public ViewResult Index()
        {
            string errormessage = "";
            if (Request.Method.ToUpper() == "POST")
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                User user = new User();
                user.UserName = username;
                user.Password = password;
                /*
                int maxId = -1;
                foreach (var existinguser in users)
                {
                    if(existinguser.Id > maxId)
                    {
                        maxId = existinguser.Id;
                    }
                }
               
                user.Id = maxId + 1;
                 */
                if (users.Count == 0)
                {
                    user.Id = 1;
                }
                else
                {
                    user.Id = users.Max(u => u.Id) + 1;
                }

                /*
                bool usernameexists = false;
                
                foreach (var currentuser in users)
                {
                    if (currentuser.UserName == user.UserName)
                    {
                        usernameexists = true;
                    }
                }

                if (!usernameexists)
                */
                if (!users.Any(u => u.UserName == user.UserName))
                {
                    users.Add(user);
                }
                else
                {
                    errormessage = "This username already exists";
                }

            }


            return View((object)errormessage);

        }

        public ViewResult Users()
        {

            return View(users);
        }

        public ViewResult User()
        {
            int Id = int.Parse(Request.Query["Id"]);
            foreach (var user in users)
            {
                if (user.Id == Id)
                {
                    return View(user);
                }
            }
            return View(null);
        }
    }
}
