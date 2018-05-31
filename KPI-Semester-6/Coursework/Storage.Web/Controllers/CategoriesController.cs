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
    public class CategoriesController : Controller
    {
        private ServiceCategories serviceCategories = new ServiceCategories();

        // GET: CategoryViews
        public ActionResult Index()
        {
            List<CategoryDM> categoriesDM = serviceCategories.GetCategories().ToList();
            List<CategoryView> categories = new List<CategoryView>();
            foreach (var c in categoriesDM)
            {
                categories.Add(new CategoryView(c));
            }
            return View(categories);
        }

        public ActionResult Error(int id)
        {
            CategoryView categoryView = new CategoryView(serviceCategories.GetCategory(Convert.ToInt32(id)));
            if (categoryView == null)
            {
                return HttpNotFound();
            }
            return View(categoryView);
        }
        // GET: CategoryViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryView categoryView = new CategoryView(serviceCategories.GetCategory(Convert.ToInt32(id)));
            if (categoryView == null)
            {
                return HttpNotFound();
            }
            return View(categoryView);
        }

        // GET: CategoryViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name")] CategoryView categoryView)
        {
            if (ModelState.IsValid)
            {
                serviceCategories.AddCategory(categoryView.ToCategory());
                return RedirectToAction("Index");
            }

            return View(categoryView);
        }

        // GET: CategoryViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryView categoryView = new CategoryView(serviceCategories.GetCategory(Convert.ToInt32(id)));
            if (categoryView == null)
            {
                return HttpNotFound();
            }
            return View(categoryView);
        }

        // POST: CategoryViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name")] CategoryView categoryView)
        {
            if (ModelState.IsValid)
            {
                serviceCategories.UpdateCategory(categoryView.ToCategory());
                return RedirectToAction("Index");
            }
            return View(categoryView);
        }

        // GET: CategoryViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryView categoryView = new CategoryView(serviceCategories.GetCategory(Convert.ToInt32(id)));
            if (categoryView == null)
            {
                return HttpNotFound();
            }
            return View(categoryView);
        }

        // POST: CategoryViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryDM category = serviceCategories.GetCategory(Convert.ToInt32(id));
            if(serviceCategories.DeleteCategory(category))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error", new { id = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceCategories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
