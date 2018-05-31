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
    public class ProductController : Controller
    {
        private ServiceProducts serviceProducts = new ServiceProducts();

        // GET: ProductViews
        public ActionResult Index(string searchString, int? sort, bool? order)
        {
            ViewBag.NameOrder = true;
            ViewBag.BrandOrder = true;
            ViewBag.PriceOrder = true;
            if(sort == null)
            {
                sort = -1;
            }
            if (order == null)
            {
                order = true;
            }
            else if(sort == 1)
            {
                ViewBag.NameOrder = !order;
                order = ViewBag.NameOrder;
            }
            else if (sort == 2)
            {
                ViewBag.BrandOrder = !order;
                order = ViewBag.BrandOrder;
            }
            else if (sort == 3)
            {
                ViewBag.PriceOrder = !order;
                order = ViewBag.PriceOrder;
            }
            ViewBag.Sort = sort;
            ViewBag.CurrentFilter = searchString;

            List<ProductView> products = new List<ProductView>();
            if (!String.IsNullOrEmpty(searchString))
            {
                foreach (var p in serviceProducts.Sort(serviceProducts.ProductSearch(searchString), (int) sort, (bool) order))
                {
                    products.Add(new ProductView(p));
                }
            }
            else
            {
                foreach (var p in serviceProducts.Sort(serviceProducts.GetProducts(), (int) sort, (bool) order))
                {
                    products.Add(new ProductView(p));
                }
            }            
            return View(products);
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
            return View();
        }

        // POST: ProductViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Brand,Quantity,Price")] ProductView productView)
        {
            if (ModelState.IsValid)
            {
                serviceProducts.AddProduct(productView.ToProduct());
                return RedirectToAction("Index");
            }

            return View(productView);
        }

        // GET: ProductViews/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: ProductViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Brand,Quantity,Price")] ProductView productView)
        {
            if (ModelState.IsValid)
            {
                serviceProducts.UpdateProduct(productView.ToProduct());
                return RedirectToAction("Index");
            }
            return View(productView);
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
        //public ActionResult AddAuthor(int? id)
        //{
        //    List<AuthorFullName> authors = new List<AuthorFullName>();
        //    var authorsDM = serviceAuthors.GetAuthors().ToList();
        //    foreach (var a in authorsDM)
        //    {
        //        authors.Add(new AuthorFullName(a));
        //    }
        //    ViewBag.Authors = authors;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
        //    if (bookView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookView);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddAuthor([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity,Authors")] BookView bookView)
        //{
        //    service.AddAuthorToBook(bookView.ToBookDM(), serviceAuthors.GetAuthor(bookView.GenreID));
        //    return RedirectToAction("Index");
        //}

        //public ActionResult DeleteAuthor(int? id)
        //{
        //    List<AuthorFullName> authors = new List<AuthorFullName>();
        //    foreach (var a in service.GetBook(Convert.ToInt32(id)).Authors)
        //    {
        //        authors.Add(new AuthorFullName(a));
        //    }
        //    ViewBag.Authors = authors;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
        //    if (bookView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookView);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteAuthor([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity,Authors")] BookView bookView)
        //{
        //    service.DeleteAuthorFromBook(bookView.ToBookDM(), serviceAuthors.GetAuthor(bookView.GenreID));
        //    return RedirectToAction("Index");
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceProducts.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
