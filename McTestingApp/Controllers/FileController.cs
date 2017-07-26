using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McTestingApp.App_Start;
using System.IO;

namespace McTestingApp.Controllers
{
    public class FileController : Controller
    {
        private McTestingAppContainer db = new McTestingAppContainer();

        // GET: File
        public ActionResult Index()
        {
            // Show all uploaded files

            // Get loggedin user and redirect to the page
            User loginUser = (User)HttpContext.Session["LoggedInUser"];

            if (!RoleHandler.isLoggedIn(loginUser))
            {
                return View("Login", "Home");
            }

            List<File> files = db.Files.ToList();

            return View(files);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        fileName += "-" + Guid.NewGuid().ToString();

                        var path = Path.Combine(Server.MapPath("~/File"), fileName);
                        file.SaveAs(path);

                        File dbFile = new File();

                        dbFile.Name = file.FileName;
                        dbFile.Path = path;

                        db.Files.Add(dbFile);
                        db.SaveChanges();
                    }
                    ViewBag.Message = "Upload successful";
                }
                catch
                {
                    ViewBag.Message = "Upload failed";
                }
            }

            return RedirectToAction("Index", "File");
        }

        public FileResult Download(long id)
        {
            File file = db.Files.FirstOrDefault(f => f.Id == id);

            return File(file.Path, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}