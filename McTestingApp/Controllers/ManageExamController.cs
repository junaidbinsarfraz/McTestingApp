using McTestingApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using McTestingApp.Models;

namespace McTestingApp.Controllers
{
    public class ManageExamController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        // GET: Exam
        public ActionResult Index()
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            //List<Test> tests = db.Tests1.Include(u => u.Results).ToList().FindAll(t => t.Published == true);

            List<Test> tests = (List<Test>)(from t in db.Tests1
                                            join r in db.Results on t.Id equals r.Test.Id
                                            where r.User.Id == loginUser.Id && r.MarksObtain != null
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
        public ActionResult View(long? id)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            Test test = db.Tests1.Include(t => t.Questions).Where(t => t.Id == id).FirstOrDefault();

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test) 
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            if(ModelState.IsValid) 
            {
                db.Tests1.Add(test);

                db.SaveChanges();

                return View("View", "ManageExam");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateQuestion(long? testId)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            ViewBag.testId = testId;

            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(long? testId, QuestionChoices questionChoices)
        {
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLevel1(loginUser))
            {
                return View("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                Question question = new Question();

                question.Description = questionChoices.Question;

                Choice choice1 = new Choice();

                choice1.ChoiceNumber = questionChoices.Choice1;

                Choice choice2 = new Choice();

                choice1.ChoiceNumber = questionChoices.Choice2;

                Choice choice3 = new Choice();

                choice1.ChoiceNumber = questionChoices.Choice3;

                Choice choice4 = new Choice();

                choice1.ChoiceNumber = questionChoices.Choice4;

                db.Choices.Add(choice1);
                db.Choices.Add(choice2);
                db.Choices.Add(choice3);
                db.Choices.Add(choice4);
                
                db.SaveChanges();


                if (questionChoices.CorrectChoice == choice1.ChoiceNumber)
                {
                    question.Choice = choice1;
                }
                else if (questionChoices.CorrectChoice == choice2.ChoiceNumber)
                {
                    question.Choice = choice2;
                }
                else if (questionChoices.CorrectChoice == choice3.ChoiceNumber)
                {
                    question.Choice = choice3;
                }
                else if (questionChoices.CorrectChoice == choice4.ChoiceNumber)
                {
                    question.Choice = choice4;
                }

                question.Choices.Add(choice1);
                question.Choices.Add(choice2);
                question.Choices.Add(choice3);
                question.Choices.Add(choice4);

                db.Questions.Add(question);

                db.SaveChanges();

                return View("View", "ManageExam");
            }

            return View();
        }
    }
}