using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace empty.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //action method
        {
            return View();
        }

        /* [HttpGet]
         [ActionName("About")]
         //from controller to view
         public ActionResult about_get()
         {*/
        public ActionResult About()
        { 
            ViewBag.Message = "Your application description page.";

            return View();
        }
       /* [HttpPost]
        [ActionName("About")]
        //from view to controller*/

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

  


    }
}