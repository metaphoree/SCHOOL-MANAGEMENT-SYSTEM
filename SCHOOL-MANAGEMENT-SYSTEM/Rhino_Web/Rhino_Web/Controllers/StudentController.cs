using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rhino_Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Rhino_Web.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class StudentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
   
        public ActionResult Index() {

            List<StudentData> list = new List<StudentData>();
            list = context.StudentDatas.ToList();


            return View(list);
        }
        [HttpPost]
        public void UploadImageUsingAjax()
        {
            //Request.Files.Count
            for (int i = 0; i <1; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Student_Uploaded_Image/"), fileName);
                ViewBag.UrlOfStudentImage = path;
                file.SaveAs(path);
            }

        }




        #region(CreateStudentPost)
        [HttpPost]
        public PartialViewResult Create(StudentData model)
        {
            model.StudentId = Guid.NewGuid().ToString();
            model.UserId =Isit.GetIdOfCurrentUserByEmail(Isit.UserEmailIs);
            if (!ModelState.IsValid)
            {
                ViewBag.IsRegistrationSuccessfull = "false";
            }

            context.StudentDatas.Add(model);
            context.SaveChanges();
            ViewBag.IsRegistrationSuccessfull = "true";


            return PartialView();
        }

        #endregion

        #region(CreateStudentGet)
        [HttpGet]
        public PartialViewResult Create() {

            ViewBag.IsRegistrationSuccessfull = "NotTestedYet";
            return PartialView();

        }
#endregion

        // GET: Search
        [HttpGet]
        public PartialViewResult SearchIndex()
        {
            /*
            var  list = context.StudentDatas.ToList().ToPagedList(page ?? 1, 2);


               return View(list);
       */

            return PartialView();
        }
        
        // POST: Search
      
        public PartialViewResult Search(string searchBy,string search,int? page)
        {
            
            if (searchBy == "Name")
            {
                return PartialView(context.StudentDatas.Where(x => x.Name.StartsWith(search)).ToList().
                    ToPagedList(page ?? 1,2));
            }
            else if (searchBy == "Roll")
            {
                return PartialView(context.StudentDatas.Where(x => x.Roll.StartsWith(search)).ToList().
                    ToPagedList(page ?? 1, 2));
            }
            else {

                return PartialView(context.StudentDatas.ToList().
                    ToPagedList(page ?? 1, 2));
            }



            
        }

        #region(CommonViewGetPost)
        [HttpGet]
        [ActionName("Common")]
        public ActionResult Common_Get() {



            return View();
        }
        [HttpPost]
        [ActionName("Common")]
        public ActionResult Common_Post()
        {



            return View();
        }
#endregion



    }
}