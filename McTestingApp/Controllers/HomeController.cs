using System.Linq;
using System.Web.Mvc;
using McTestingApp.App_Start;

namespace McTestingApp.Controllers
{
    public class HomeController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        [HttpGet]
        public ActionResult Create()
        {
            User user = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isAdmin(user))
            {
                return View("Login", "Home");
            }

            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create(User user)
        {
            if (!RoleHandler.isAdmin((User)HttpContext.Session["LoggedInUser"]))
            {
                return View("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                User dbUser = db.Users.FirstOrDefault(u => u.Username == user.Username);

                if (dbUser != null)
                {
                    ModelState.AddModelError("Error", "Username already exists");
                    return View();
                }

                db.Users.Add(user);

                // Level 1
                if (Designation.Training_Exective.ToString() == user.Designation || Designation.Assistant_Manager_Training.ToString() == user.Designation 
                    || Designation.Manager_Training.ToString() == user.Designation || Designation.Divisional_Manager_Training.ToString() == user.Designation)
                {
                    user.Role = Role.Level1.ToString();
                }
                else if (Designation.National_Manager_Training.ToString() == user.Designation || Designation.Assistant_Director_HR_Training.ToString() == user.Designation
                    || Designation.Resturant_Manager.ToString() == user.Designation || Designation.Operation_Consultant.ToString() == user.Designation)
                {
                    user.Role = Role.Level2.ToString();
                }
                else
                {
                    user.Role = Role.Level3.ToString();
                }

                db.SaveChanges();

                ModelState.AddModelError("Success", "User successfully added");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (RoleHandler.isLoggedIn(loginUser))
            {
                //return View("Login", "Home");
                // Check the role then send user to specific page
            }

            return View();
        }

        // Do login for a user and redirect to specific page w.r.t. user role
        [HttpPost]
        public ActionResult Login(User user)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (RoleHandler.isLoggedIn(loginUser))
            {
                //return View("Login", "Home");
                // Check the role then send user to specific page
            }

            if (ModelState.IsValid)
            {
                User dbUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (dbUser != null)
                {
                    // Save role to session then redirect to role specific dashboard

                    HttpContext.Session["LoggedInUser"] = dbUser;

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