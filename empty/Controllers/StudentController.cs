using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace empty.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index() //public & cannot be overloaded & can not be static
        {
            return View();
        }
    }
}