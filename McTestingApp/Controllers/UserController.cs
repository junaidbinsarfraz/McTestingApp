using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McTestingApp.App_Start;

namespace McTestingApp.Controllers
{
    public class UserController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        // GET: User
        public ActionResult Index()
        {
            // Get loggedin user and redirect to the page
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLoggedIn(loginUser))
            {
                return View("Login", "Home");
            }

            return View(loginUser);
        }

        // GET: User
        public ActionResult Edit()
        {
            // Get loggedin user and redirect to the page
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLoggedIn(loginUser))
            {
                return View("Login", "Home");
            }

            return View(loginUser);
        }

        public ActionResult Edit(User user)
        {
            // Get loggedin user and redirect to the page
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLoggedIn(loginUser))
            {
                return View("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                User oldUser = db.Users.FirstOrDefault(u => u.Id == user.Id);

                oldUser.Name = user.Name;
                oldUser.Email = user.Email;

                db.SaveChanges();

                HttpContext.Session["LoggedInUser"] = oldUser;

                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}