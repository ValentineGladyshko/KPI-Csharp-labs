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
    public class ProviderViewsController : Controller
    {
        private StorageWebContext db = new StorageWebContext();

        // GET: ProviderViews
        public ActionResult Index()
        {
            return View(db.ProviderViews.ToList());
        }

        // GET: ProviderViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderView providerView = db.ProviderViews.Find(id);
            if (providerView == null)
            {
                return HttpNotFound();
            }
            return View(providerView);
        }

        // GET: ProviderViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviderViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProviderID,FirstName,LastName")] ProviderView providerView)
        {
            if (ModelState.IsValid)
            {
                db.ProviderViews.Add(providerView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providerView);
        }

        // GET: ProviderViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderView providerView = db.ProviderViews.Find(id);
            if (providerView == null)
            {
                return HttpNotFound();
            }
            return View(providerView);
        }

        // POST: ProviderViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProviderID,FirstName,LastName")] ProviderView providerView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerView);
        }

        // GET: ProviderViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderView providerView = db.ProviderViews.Find(id);
            if (providerView == null)
            {
                return HttpNotFound();
            }
            return View(providerView);
        }

        // POST: ProviderViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderView providerView = db.ProviderViews.Find(id);
            db.ProviderViews.Remove(providerView);
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
