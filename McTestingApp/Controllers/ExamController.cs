using McTestingApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace McTestingApp.Controllers
{
    public class ExamController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        // GET: Exam
        public ActionResult Index()
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel3(loginUser))
            {
                return View("Login", "Home");
            }

            //List<Test> tests = db.Tests1.Include(u => u.Results).ToList().FindAll(t => t.Published == true);

            List<Test> tests = (List<Test>)(from t in db.Tests1
                                            join r in db.Results on t.Id equals r.Test.Id
                                            where r.User.Id == loginUser.Id && r.MarksObtain == null
                                            select new
                                            {
                                                t.Id,
                                                t.Name,
                                                t.Published
                                            }).AsEnumerable()
                                .Select(t => new Test
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Published = t.Published
                                })
                                .ToList();

            return View(tests);
        }

        [HttpGet]
        public ActionResult Take(long? id)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel3(loginUser))
            {
                return View("Login", "Home");
            }

            Test test = db.Tests1.Include(t => t.Questions.Select(q => q.Choices)).FirstOrDefault(t => t.Id == id);

            //db.Tests1.Include(t => t.Questions).Where(t => t.Id == 1);

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        [HttpPost]
        public ActionResult Take(Test test)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel3(loginUser))
            {
                return View("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                if (test == null)
                {
                    ModelState.AddModelError("Error", "Test not found");
                    return View();
                }

                // TODO: Check, save and display result
                //Test dbTest = db.Tests1.Include(t => t.Questions.Select(q => q.Choice)).FirstOrDefault(t => t.Id == test.Id);
            }
            return View();
        }
    }
}