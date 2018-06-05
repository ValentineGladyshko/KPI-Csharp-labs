using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Storage.Web.Models;
using Storage.BLL.DataModels;
using Storage.BLL.Services;

namespace Library.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ServiceProducts serviceProducts = new ServiceProducts();
        private ServiceCategories serviceCategories = new ServiceCategories();

        // GET: ProductViews
        public ActionResult Index()
        {
            TempData["sort"] = new ProductSort();
            TempData.Keep();
            return View("");
        }

        public PartialViewResult GetProducts(string searchString, int sortType)
        {
            ProductSort sort = TempData["sort"] as ProductSort;
            TempData.Keep();
            if (searchString != "`")
                sort.SearchString = searchString;
            sort.GetSort(sortType);
            TempData["sort"] = sort;
            TempData.Keep();
            List<ProductView> products = new List<ProductView>();
            if (!String.IsNullOrEmpty(sort.SearchString))
            {
                foreach (var p in serviceProducts.Sort(serviceProducts.ProductSearch(sort.SearchString), sort.Sort, sort.GetOrder()))
                {
                    products.Add(new ProductView(p));
                }
            }
            else
            {
                foreach (var p in serviceProducts.Sort(serviceProducts.GetProducts(), sort.Sort, sort.GetOrder()))
                {
                    products.Add(new ProductView(p));
                }
            }
            return PartialView(products);
        }

        // GET: ProductViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductView productView = new ProductView(serviceProducts.GetProduct(Convert.ToInt32(id)));
            if (productView == null)
            {
                return HttpNotFound();
            }
            return View(productView);
        }

        // GET: ProductViews/Create
        public ActionResult Create()
        {
            ProductEdit productEdit = new ProductEdit(serviceCategories.GetCategories()); 
            return View(productEdit);
        }

        // POST: ProductViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Brand,CategoryID,Quantity,Price")] ProductEdit productEdit)
        {
            if (ModelState.IsValid)
            {
                serviceProducts.AddProduct(productEdit.ToProduct());
                return RedirectToAction("Index");
            }

            return View(productEdit);
        }

        // GET: ProductViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEdit productEdit = new ProductEdit(serviceProducts.GetProduct(Convert.ToInt32(id)), serviceCategories.GetCategories());

            if (productEdit == null)
            {
                return HttpNotFound();
            }
            return View(productEdit);
        }

        // POST: ProductViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Brand,CategoryID,Quantity,Price")] ProductEdit productEdit)
        {
            if (ModelState.IsValid)
            {
                serviceProducts.UpdateProduct(productEdit.ToProduct());
                return RedirectToAction("Index");
            }
            return View(productEdit);
        }

        // GET: ProductViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductView productView = new ProductView(serviceProducts.GetProduct(Convert.ToInt32(id)));
            if (productView == null)
            {
                return HttpNotFound();
            }
            return View(productView);
        }

        // POST: ProductViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDM product = serviceProducts.GetProduct(Convert.ToInt32(id));
            serviceProducts.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceProducts.Dispose();
                serviceCategories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
