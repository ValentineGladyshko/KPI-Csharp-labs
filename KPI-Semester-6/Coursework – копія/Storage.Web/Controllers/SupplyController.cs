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
    public class SupplyViewsController : Controller
    {
        private StorageWebContext db = new StorageWebContext();

        // GET: SupplyViews
        public ActionResult Index()
        {
            return View(db.SupplyViews.ToList());
        }

        // GET: SupplyViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyView supplyView = db.SupplyViews.Find(id);
            if (supplyView == null)
            {
                return HttpNotFound();
            }
            return View(supplyView);
        }

        // GET: SupplyViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyID,Quantity,Price,SupplyDate")] SupplyView supplyView)
        {
            if (ModelState.IsValid)
            {
                db.SupplyViews.Add(supplyView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplyView);
        }

        // GET: SupplyViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyView supplyView = db.SupplyViews.Find(id);
            if (supplyView == null)
            {
                return HttpNotFound();
            }
            return View(supplyView);
        }

        // POST: SupplyViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplyID,Quantity,Price,SupplyDate")] SupplyView supplyView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplyView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplyView);
        }

        // GET: SupplyViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyView supplyView = db.SupplyViews.Find(id);
            if (supplyView == null)
            {
                return HttpNotFound();
            }
            return View(supplyView);
        }

        // POST: SupplyViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplyView supplyView = db.SupplyViews.Find(id);
            db.SupplyViews.Remove(supplyView);
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
