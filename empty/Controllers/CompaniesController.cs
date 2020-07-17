using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using empty.Models;
using System.IO;

namespace empty.Controllers
{
    public class CompaniesController : Controller
    {
        private DBPharmacyEntities1 db = new DBPharmacyEntities1();

        // GET: Companies
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View(db.Company.ToList());
            }
            else
                return RedirectToAction("login");
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login");
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CID,Cname,Ctype,EDate,capital,logo,Curl")] Company company ,HttpPostedFileBase fileimg)
        {
            if (ModelState.IsValid)
            {
                //if(company.capital<10000)
                //{
                //    ModelState.AddModelError("capital", "Capetal is less than 10000");
                //    return View(company);
                //}



                string path = "";
                if(fileimg.FileName.Length>0)
                {
                    path = "~/Images/" + Path.GetFileName(fileimg.FileName)+DateTime.Now;
                    fileimg.SaveAs(Server.MapPath(path));
                }
                company.logo = path;
                db.Company.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID,Cname,Ctype,Email,EDate,password,capital,logo,Curl")] Company company, HttpPostedFileBase fileimg)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if (fileimg.FileName.Length > 0)
                {
                    path = "~/Images/" + Path.GetFileName(fileimg.FileName) + DateTime.Now;
                    fileimg.SaveAs(Server.MapPath(path));
                }
                company.logo = path;
               
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Company.Find(id);
            db.Company.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int Count()
        {
            return db.Company.ToList().Count;
        }

        public int Max()
        {
            return db.Company.Max(m => m.capital).Value;
        }

        public int Min()
        {
            return db.Company.Min(m => m.capital).Value;
        }

        public double Avarage()
        {
            return db.Company.Average(m => m.capital).Value;
        }

        public ActionResult  getmany()
        {
            //var res = db.Company.ToList();
            //var res = db.Company.ToList().OrderBy(x => x.capital);

            //var res = db.Company.Where(x => x.capital >= 3000 && x.capital <= 100000).ToList();
            double avg = db.Company.Average(x => x.capital).Value;
            var res = db.Company.Where(x => x.capital > avg).ToList();
            return View(res);
        }
        public ActionResult getone()
        {
            //var res = db.Company.Find(2);
            //  var res = db.Company.Single(x => x.CID == 2);
            var res = db.Company.Where(x => x.CID == 3).ToList().FirstOrDefault();
            return View(res);
        }

        public ActionResult login()
        {
            Session["username"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult login([Bind(Include = "Email,password")] Company company)
        {
            var rec = db.Company.Where(x => x.Email == company.Email && x.password == company.password).ToList().FirstOrDefault();
            if (rec != null)
            {
                Session["Username"] = rec.Cname;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Invalid User";
                return View(company);
            }
        }
    }
}
