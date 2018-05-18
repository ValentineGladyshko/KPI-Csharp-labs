using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Web.Models;
using Library.BLL.DataModels;
using Library.BLL.Services;

namespace Library.Web.Controllers
{
    public class AuthorViewsController : Controller
    {
        private ServiceAuthors service = new ServiceAuthors();

        // GET: AuthorViews
        public ActionResult Index()
        {
            List<AuthorDM> authorsDM = service.GetAuthors().ToList();
            List<AuthorView> authors = new List<AuthorView>();
            foreach (var a in authorsDM)
            {
                authors.Add(new AuthorView(a));
            }
            return View(authors);
        }

        // GET: AuthorViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorView authorView = new AuthorView(service.GetAuthor(Convert.ToInt32(id)));
            if (authorView == null)
            {
                return HttpNotFound();
            }
            return View(authorView);
        }

        // GET: AuthorViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorID,FirstName,LastName")] AuthorView authorView)
        {
            if (ModelState.IsValid)
            {
                service.AddAuthor(authorView.ToAuthorDM());
                return RedirectToAction("Index");
            }

            return View(authorView);
        }

        // GET: AuthorViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorView authorView = new AuthorView(service.GetAuthor(Convert.ToInt32(id)));
            if (authorView == null)
            {
                return HttpNotFound();
            }
            return View(authorView);
        }

        // POST: AuthorViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorID,FirstName,LastName")] AuthorView authorView)
        {
            if (ModelState.IsValid)
            {
                service.UpdateAuthor(authorView.ToAuthorDM());
                return RedirectToAction("Index");
            }
            return View(authorView);
        }

        // GET: AuthorViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorView authorView = new AuthorView(service.GetAuthor(Convert.ToInt32(id)));
            if (authorView == null)
            {
                return HttpNotFound();
            }
            return View(authorView);
        }

        // POST: AuthorViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteAuthor(service.GetAuthor(Convert.ToInt32(id)));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
