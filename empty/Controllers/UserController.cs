using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace empty.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            ViewBag.vb = "hello";
            ViewData["v"] = "yes";
            TempData["fefe"] = "no";
            Session["hi"] = "i love to eat";
            // return View();
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult sum()
        {
            ViewBag.n1 = 0;
            ViewBag.n2 = 0;
           
            return View();
        }

        [HttpPost]
        public ActionResult sum(int t1,int t2)
        {
            int s = t1 + t2;

            TempData["sum"] = s;
            return RedirectToAction("result");
        }
        public ActionResult result()
        {

            return View();
        }
        [HttpPost]
        [ActionName("result")]
        public ActionResult result_post()
        {

            return RedirectToAction("sum");
        }
        /*    [ActionName("sum")]
            [HttpGet]
            public ActionResult sum_get()
            {
                ViewBag.no1 = 0;
                ViewBag.no2 = 0;
                ViewBag.result = 0;
                return View();
            }
        */
        /*  [ActionName("sum")]
          [HttpPost]
          public ActionResult sum_post(FormCollection obj)
          {
              int n1 =int.Parse( obj["n1"]);
              int n2 =int.Parse( obj["n2"]);

              int sum = n1 + n2;
              ViewBag.result = sum;

              ViewBag.no1 = n1;
              ViewBag.no2 = n2;
              return View();
          }
        */
    }
}