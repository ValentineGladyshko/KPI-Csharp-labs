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
    public class CustomersController : Controller
    {
        private ServiceCustomers serviceCustomers = new ServiceCustomers();

        // GET: CustomerViews
        public ActionResult Index()
        {
            TempData["sort"] = new PersonSort();
            TempData.Keep();
            return View("");
        }

        // GET: CustomerViews/Details/5
        public PartialViewResult GetCustomers(string searchString, int sortType)
        {
            PersonSort sort = TempData["sort"] as PersonSort;
            TempData.Keep();
            if (searchString != "`")
                sort.SearchString = searchString;
            sort.GetSort(sortType);
            TempData["sort"] = sort;
            TempData.Keep();
            List<CustomerView> customers = new List<CustomerView>();
            if (!String.IsNullOrEmpty(sort.SearchString))
            {
                foreach (var c in serviceCustomers.Sort(serviceCustomers.CustomerSearch(sort.SearchString), sort.Sort, sort.GetOrder()))
                {
                    customers.Add(new CustomerView(c));
                }
            }
            else
            {
                foreach (var c in serviceCustomers.Sort(serviceCustomers.GetCustomers(), sort.Sort, sort.GetOrder()))
                {
                    customers.Add(new CustomerView(c));
                }
            }
            return PartialView(customers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerView customerView = new CustomerView(serviceCustomers.GetCustomer(Convert.ToInt32(id)));
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
                serviceCustomers.AddCustomer(customerView.ToCustomer());
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
            CustomerView customerView = new CustomerView(serviceCustomers.GetCustomer(Convert.ToInt32(id)));
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
                serviceCustomers.UpdateCustomer(customerView.ToCustomer());
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
            CustomerView customerView = new CustomerView(serviceCustomers.GetCustomer(Convert.ToInt32(id)));
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
            CustomerDM customer = serviceCustomers.GetCustomer(Convert.ToInt32(id));
            serviceCustomers.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceCustomers.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
