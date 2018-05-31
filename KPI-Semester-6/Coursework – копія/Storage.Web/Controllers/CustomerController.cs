using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storage.Web.Models;

namespace Library.Web.Controllers
{
    public class CustomerViewsController : Controller
    {
        private StorageWebContext db = new StorageWebContext();

        // GET: CustomerViews
        public ActionResult Index()
        {
            return View(db.CustomerViews.ToList());
        }

        // GET: CustomerViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerView customerView = db.CustomerViews.Find(id);
            if (customerView == null)
            {
                return HttpNotFound();
            }
            return View(customerView);
        }

        // GET: CustomerViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName")] CustomerView customerView)
        {
            if (ModelState.IsValid)
            {
                db.CustomerViews.Add(customerView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerView);
        }

        // GET: CustomerViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerView customerView = db.CustomerViews.Find(id);
            if (customerView == null)
            {
                return HttpNotFound();
            }
            return View(customerView);
        }

        // POST: CustomerViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName")] CustomerView customerView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerView);
        }

        // GET: CustomerViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerView customerView = db.CustomerViews.Find(id);
            if (customerView == null)
            {
                return HttpNotFound();
            }
            return View(customerView);
        }

        // POST: CustomerViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerView customerView = db.CustomerViews.Find(id);
            db.CustomerViews.Remove(customerView);
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
    }
}
