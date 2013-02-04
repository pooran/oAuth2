using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth2.Controllers
{
    public class ProvisionController : Controller
    {
        private oAuthEntities db = new oAuthEntities();

        //
        // GET: /Provision/

        public ActionResult Index()
        {
            var provisions = db.Provisions.Include(p => p.Application).Include(p => p.Customer);
            return View(provisions.ToList());
        }

        //
        // GET: /Provision/Details/5

        public ActionResult Details(int id = 0)
        {
            Provision provision = db.Provisions.Find(id);
            if (provision == null)
            {
                return HttpNotFound();
            }
            return View(provision);
        }

        //
        // GET: /Provision/Create

        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Applications, "ApplicationId", "ApplicationName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        //
        // POST: /Provision/Create

        [HttpPost]
        public ActionResult Create(Provision provision)
        {
            if (ModelState.IsValid)
            {
                db.Provisions.Add(provision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationId = new SelectList(db.Applications, "ApplicationId", "ApplicationName", provision.ApplicationId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", provision.CustomerId);
            return View(provision);
        }

        //
        // GET: /Provision/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Provision provision = db.Provisions.Find(id);
            if (provision == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.Applications, "ApplicationId", "ApplicationName", provision.ApplicationId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", provision.CustomerId);
            return View(provision);
        }

        //
        // POST: /Provision/Edit/5

        [HttpPost]
        public ActionResult Edit(Provision provision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Applications, "ApplicationId", "ApplicationName", provision.ApplicationId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", provision.CustomerId);
            return View(provision);
        }

        //
        // GET: /Provision/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Provision provision = db.Provisions.Find(id);
            if (provision == null)
            {
                return HttpNotFound();
            }
            return View(provision);
        }

        //
        // POST: /Provision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Provision provision = db.Provisions.Find(id);
            db.Provisions.Remove(provision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}