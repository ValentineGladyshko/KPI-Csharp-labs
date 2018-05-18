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
    public class BookViewsController : Controller
    {
        private ServiceBooks service = new ServiceBooks();
        private ServiceGenres serviceGenres = new ServiceGenres();
        private ServiceAuthors serviceAuthors = new ServiceAuthors();

        // GET: BookViews
        public ActionResult Index(string searchString)
        {
            List<BookView> books = new List<BookView>();
            List<BookDM> booksDM = new List<BookDM>();
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                booksDM = service.BookSearch(searchString).ToList();
            }
            else
            {
                booksDM = service.GetBooks().ToList();  
            }
            foreach (var b in booksDM)
            {
                BookView book = new BookView(b);
                book.Genre = new GenreView(serviceGenres.GetGenre(book.GenreID));
                books.Add(book);
            }
            return View(books);
        }

        public ActionResult DeleteError(int id)
        {
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }
        // GET: BookViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        // GET: BookViews/Create
        public ActionResult Create()
        {
            ViewBag.Genres = serviceGenres.GetGenres().ToList();
            return View();
        }

        // POST: BookViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity")] BookView bookView)
        {
            ViewBag.Genres = serviceGenres.GetGenres().ToList();
            if (ModelState.IsValid)
            {
                service.AddBook(bookView.ToBookDM());
                return RedirectToAction("Index");
            }

            return View(bookView);
        }

        // GET: BookViews/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Genres = serviceGenres.GetGenres().ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        // POST: BookViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity,Authors")] BookView bookView)
        {
            ViewBag.Genres = serviceGenres.GetGenres().ToList();
            if (ModelState.IsValid)
            {
                service.UpdateBook(bookView.ToBookDM());
                return RedirectToAction("Index");
            }
            return View(bookView);
        }

        // GET: BookViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        // POST: BookViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookDM bookDM = service.GetBook(Convert.ToInt32(id));
            bool flag = service.DeleteBook(bookDM);
            if (flag)
                return RedirectToAction("Index");
            else
                return RedirectToAction("DeleteError", new { id = id });
        }

        public ActionResult AddAuthor(int? id)
        {
            List<AuthorFullName> authors = new List<AuthorFullName>();
            var authorsDM = serviceAuthors.GetAuthors().ToList();
            foreach(var a in authorsDM)
            {
                authors.Add(new AuthorFullName(a));
            }
            ViewBag.Authors = authors;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthor([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity,Authors")] BookView bookView)
        {
            service.AddAuthorToBook(bookView.ToBookDM(), serviceAuthors.GetAuthor(bookView.GenreID));
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAuthor(int? id)
        {
            List<AuthorFullName> authors = new List<AuthorFullName>();
            foreach (var a in service.GetBook(Convert.ToInt32(id)).Authors)
            {
                authors.Add(new AuthorFullName(a));
            }
            ViewBag.Authors = authors;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookView bookView = new BookView(service.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor([Bind(Include = "BookID,Name,GenreID,PublishDate,Quantity,Authors")] BookView bookView)
        {
            service.DeleteAuthorFromBook(bookView.ToBookDM(), serviceAuthors.GetAuthor(bookView.GenreID));
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
