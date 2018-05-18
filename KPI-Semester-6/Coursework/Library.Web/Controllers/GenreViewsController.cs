using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Web.Models;
using Library.BLL.Services;
using Library.BLL.DataModels;

namespace Library.Web.Controllers
{
    public class GenreViewsController : Controller
    {
        private ServiceGenres service = new ServiceGenres();

        // GET: GenreViews
        public ActionResult Index()
        {
            List<GenreDM> genresDM = service.GetGenres().ToList();
            List<GenreView> genres = new List<GenreView>();
            foreach(var g in genresDM)
            {
                genres.Add(new GenreView(g));
            }
            return View(genres);
        }

        public ActionResult Error(int id)
        {
            GenreView genreView = new GenreView(service.GetGenre(Convert.ToInt32(id)));
            if (genreView == null)
            {
                return HttpNotFound();
            }
            return View(genreView);
        }
        // GET: GenreViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreView genreView = new GenreView(service.GetGenre(Convert.ToInt32(id)));
            if (genreView == null)
            {
                return HttpNotFound();
            }
            return View(genreView);
        }

        // GET: GenreViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID,Name")] GenreView genreView)
        {
            if (ModelState.IsValid)
            {
                service.AddGenre(genreView.ToGenreDM());
                return RedirectToAction("Index");
            }

            return View(genreView);
        }

        // GET: GenreViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreView genreView = new GenreView(service.GetGenre(Convert.ToInt32(id)));
            if (genreView == null)
            {
                return HttpNotFound();
            }
            return View(genreView);
        }

        // POST: GenreViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreID,Name")] GenreView genreView)
        {
            if (ModelState.IsValid)
            {
                service.UpdateGenre(genreView.ToGenreDM());
                return RedirectToAction("Index");
            }
            return View(genreView);
        }

        // GET: GenreViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreView genreView = new GenreView(service.GetGenre(Convert.ToInt32(id)));
            if (genreView == null)
            {
                return HttpNotFound();
            }
            return View(genreView);
        }

        // POST: GenreViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreDM genreDM = service.GetGenre(Convert.ToInt32(id));
            bool flag = service.DeleteGenre(genreDM);
            if (flag)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error", new { id = id });
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
