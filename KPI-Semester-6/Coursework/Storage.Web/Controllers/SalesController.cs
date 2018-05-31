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
    public class SalesController : Controller
    {
        private ServiceSales serviceSales = new ServiceSales();
        private ServiceProducts serviceProducts = new ServiceProducts();
        private ServiceCustomers serviceCustomers = new ServiceCustomers();

        // GET: SaleViews
        public ActionResult Index()
        {
            List<SaleView> sales = new List<SaleView>();
            foreach (var s in serviceSales.GetSales())
            {
                sales.Add(new SaleView(s));
            }
            
            return View(sales);
        }

        public ActionResult SaleProducts()
        {
            List<SaleProductView> sales = new List<SaleProductView>();
            foreach (var s in serviceSales.GetSaleProducts())
            {
                sales.Add(new SaleProductView(s));
            }

            return View(sales);
        }

        public ActionResult SaleCustomers()
        {
            List<SaleCustomerView> sales = new List<SaleCustomerView>();
            foreach (var s in serviceSales.GetSaleCustomers())
            {
                sales.Add(new SaleCustomerView(s));
            }

            return View(sales);
        }

        // GET: SaleViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleView saleView = new SaleView(serviceSales.GetSale(Convert.ToInt32(id)));
            if (saleView == null)
            {
                return HttpNotFound();
            }
            return View(saleView);
        }

        // GET: SaleViews/Create
        public ActionResult Create()
        {
            SaleEdit saleEdit = new SaleEdit(serviceProducts.GetProducts(),serviceCustomers.GetCustomers());
            return View(saleEdit);
        }

        // POST: SaleViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,Customer.CustomerID,Product.ProductID,Quantity,SaleDate")] SaleEdit saleEdit)
        {
            if (ModelState.IsValid)
            {
                serviceSales.AddSale(saleEdit.ToSale());
                return RedirectToAction("Index");
            }

            return View(saleEdit);
        }

        // GET: SaleViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleEdit saleEdit = new SaleEdit(serviceSales.GetSale(Convert.ToInt32(id)), 
                serviceProducts.GetProducts(), serviceCustomers.GetCustomers());
            if (saleEdit == null)
            {
                return HttpNotFound();
            }
            return View(saleEdit);
        }

        // POST: SaleViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,Customer.CustomerID,Product.ProductID,Quantity,SaleDate")] SaleEdit saleEdit)
        {
            if (ModelState.IsValid)
            {
                serviceSales.UpdateSale(saleEdit.ToSale());
                return RedirectToAction("Index");
            }
            return View(saleEdit);
        }

        // GET: SaleViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleView saleView = new SaleView(serviceSales.GetSale(Convert.ToInt32(id)));
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
            SaleDM sale = serviceSales.GetSale(Convert.ToInt32(id));
            serviceSales.DeleteSale(sale);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceSales.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
