using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int EmpId)
        {
            var employees = new[] {
                new{  EmpId=1, EmpName="Schott", Salary=8000},
                new{  EmpId=2, EmpName="Smith", Salary=18000},
                new{  EmpId=3, EmpName="Allen", Salary=4000},
            };

            string matchEmpName = null;
            foreach (var item in employees)
            {
                if (item.EmpId == EmpId)
                {
                    matchEmpName = item.EmpName;
                }
            }
            return Content(matchEmpName, "text/plain");
        }
        // usinf file result to return file
        /* public  ActionResult GetPaySlip(int EmpId)
         //{
          //   string filename = "~/PaySlip"+ EmpId+ ".pdf";

           //  return File(fileName,"application/pdf");
        */
        //using Route to redirect
        public ActionResult EmpFacebookPage(int EmpId)
        {
            var employees = new[] {
                new{  EmpId=1, EmpName="Schott", Salary=8000},
                new{  EmpId=2, EmpName="Smith", Salary=18000},
                new{  EmpId=3, EmpName="Allen", Salary=4000},
            };

            string fbUrl = null;
            foreach (var item in employees)
            {
                if (item.EmpId == EmpId)
                {
                    fbUrl = "http://www.facebook.com/emp" + EmpId;
                }
            }
            if (fbUrl == null)
            {
                return Content("invalid emp id");
            }
            else
            {
                return Redirect(fbUrl);
            }

        }
        //Using Viewbag 
        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Schott";
            ViewBag.Marks = 20;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths", "Physics", "Chemistry" };
            return View();
        }
        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }

        public ActionResult ResponseExample()
        {
            Response.Write("Hello From Response Example");
            Response.ContentType = "text/html";
            Response.Headers["Server"] = "My Server";
            return View();                  
        }
    }

}
       
    