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
    public class SaleViewsController : Controller
    {
        private StorageWebContext db = new StorageWebContext();

        // GET: SaleViews
        public ActionResult Index()
        {
            return View(db.SaleViews.ToList());
        }

        // GET: SaleViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleView saleView = db.SaleViews.Find(id);
            if (saleView == null)
            {
                return HttpNotFound();
            }
            return View(saleView);
        }

        // GET: SaleViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,Quantity,SaleDate")] SaleView saleView)
        {
            if (ModelState.IsValid)
            {
                db.SaleViews.Add(saleView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleView);
        }

        // GET: SaleViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleView saleView = db.SaleViews.Find(id);
            if (saleView == null)
            {
                return HttpNotFound();
            }
            return View(saleView);
        }

        // POST: SaleViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,Quantity,SaleDate")] SaleView saleView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleView);
        }

        // GET: SaleViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleView saleView = db.SaleViews.Find(id);
            if (saleView == null)
            {
                return HttpNotFound();
            }
            return View(saleView);
        }

        // POST: SaleViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleView saleView = db.SaleViews.Find(id);
            db.SaleViews.Remove(saleView);
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
