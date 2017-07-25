using McTestingApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }
    }
}