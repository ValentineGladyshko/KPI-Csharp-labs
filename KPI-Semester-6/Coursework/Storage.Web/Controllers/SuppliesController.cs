using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storage.Web.Models;
using Storage.BLL.DataModels;
using Storage.BLL.Services;

namespace Library.Web.Controllers
{
    public class SuppliesController : Controller
    {
        private ServiceSupplies serviceSupplies = new ServiceSupplies();
        private ServiceProducts serviceProducts = new ServiceProducts();
        private ServiceProviders serviceProviders = new ServiceProviders();

        // GET: SupplyViews
        public ActionResult Index()
        {
            List<SupplyView> supplies = new List<SupplyView>();
            foreach (var s in serviceSupplies.GetSupplies())
            {
                supplies.Add(new SupplyView(s));
            }

            return View(supplies);
        }

        public ActionResult SupplyProducts()
        {
            List<SupplyProductView> supplies = new List<SupplyProductView>();
            foreach (var s in serviceSupplies.GetSupplyProducts())
            {
                supplies.Add(new SupplyProductView(s));
            }

            return View(supplies);
        }

        public ActionResult SupplyProviders()
        {
            List<SupplyProviderView> supplies = new List<SupplyProviderView>();
            foreach (var s in serviceSupplies.GetSupplyProviders())
            {
                supplies.Add(new SupplyProviderView(s));
            }

            return View(supplies);
        }

        // GET: SupplyViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyView supplyView = new SupplyView(serviceSupplies.GetSupply(Convert.ToInt32(id)));
            if (supplyView == null)
            {
                return HttpNotFound();
            }
            return View(supplyView);
        }

        // GET: SupplyViews/Create
        public ActionResult Create()
        {
            SupplyEdit supplyEdit = new SupplyEdit(serviceProducts.GetProducts(), serviceProviders.GetProviders());
            return View(supplyEdit);
        }

        // POST: SupplyViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyID,Provider.ProviderID,Product.ProductID,Quantity,Price,SupplyDate")] SupplyEdit supplyEdit)
        {
            if (ModelState.IsValid)
            {
                serviceSupplies.AddSupply(supplyEdit.ToSupply());
                return RedirectToAction("Index");
            }

            return View(supplyEdit);
        }

        // GET: SupplyViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyEdit supplyEdit = new SupplyEdit(serviceSupplies.GetSupply(Convert.ToInt32(id)),
                serviceProducts.GetProducts(), serviceProviders.GetProviders());
            if (supplyEdit == null)
            {
                return HttpNotFound();
            }
            return View(supplyEdit);
        }

        // POST: SupplyViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplyID,Provider.ProviderID,Product.ProductID,Quantity,Price,SupplyDate")] SupplyEdit supplyEdit)
        {
            if (ModelState.IsValid)
            {
                serviceSupplies.UpdateSupply(supplyEdit.ToSupply());
                return RedirectToAction("Index");
            }
            return View(supplyEdit);
        }

        // GET: SupplyViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyView supplyView = new SupplyView(serviceSupplies.GetSupply(Convert.ToInt32(id)));
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
            SupplyDM supply = serviceSupplies.GetSupply(Convert.ToInt32(id));
            serviceSupplies.DeleteSupply(supply);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceSupplies.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
