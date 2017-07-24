using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McTestingApp.Controllers
{
    public class HomeController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //New...   
        [HttpPost, ActionName("Create")]
        public ActionResult Create(User User)
        {
            McTestingAppContainer db = new McTestingAppContainer();

            List<User> users = db.Users.ToList();



            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Do login for a user and redirect to specific page w.r.t. user role
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User dbUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (dbUser != null)
                {
                    // Save role to session then redirect to role specific dashboard

                    return View();
                }
                // Invalid credentials
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View();
        }
    }
}