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
    public class ProvidersController : Controller
    {
        private ServiceProviders serviceProviders = new ServiceProviders();

        // GET: ProviderViews
        public ActionResult Index()
        {
            TempData["sort"] = new PersonSort();
            TempData.Keep();
            return View("");
        }

        public PartialViewResult GetProviders(string searchString, int sortType)
        {
            PersonSort sort = TempData["sort"] as PersonSort;
            TempData.Keep();
            if (searchString != "`")
                sort.SearchString = searchString;
            sort.GetSort(sortType);
            TempData["sort"] = sort;
            TempData.Keep();
            List<ProviderView> providers = new List<ProviderView>();
            if (!String.IsNullOrEmpty(sort.SearchString))
            {
                foreach (var p in serviceProviders.Sort(serviceProviders.ProviderSearch(sort.SearchString), sort.Sort, sort.GetOrder()))
                {
                    providers.Add(new ProviderView(p));
                }
            }
            else
            {
                foreach (var p in serviceProviders.Sort(serviceProviders.GetProviders(), sort.Sort, sort.GetOrder()))
                {
                    providers.Add(new ProviderView(p));
                }
            }
            return PartialView(providers);
        }

        // GET: ProviderViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderView providerView = new ProviderView(serviceProviders.GetProvider(Convert.ToInt32(id)));
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
                serviceProviders.AddProvider(providerView.ToProvider());
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
            ProviderView providerView = new ProviderView(serviceProviders.GetProvider(Convert.ToInt32(id)));
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
                serviceProviders.UpdateProvider(providerView.ToProvider());
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
            ProviderView providerView = new ProviderView(serviceProviders.GetProvider(Convert.ToInt32(id)));
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
            ProviderDM provider = serviceProviders.GetProvider(Convert.ToInt32(id));
            serviceProviders.DeleteProvider(provider);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceProviders.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
