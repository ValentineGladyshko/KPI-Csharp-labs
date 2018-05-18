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
    public class UserViewsController : Controller
    {
        private ServiceUsers service = new ServiceUsers();
        private ServiceBooks serviceBooks = new ServiceBooks();

        // GET: UserViews
        public ActionResult Index()
        {
            List<UserDM> usersDM = service.GetUsers().ToList();
            List<UserView> users = new List<UserView>();
            foreach (var u in usersDM)
            {
                users.Add(new UserView(u));
            }
            return View(users);
        }

        public ActionResult BookError(int id)
        {
            BookView bookView = new BookView(serviceBooks.GetBook(Convert.ToInt32(id)));
            if (bookView == null)
            {
                return HttpNotFound();
            }
            return View(bookView);
        }

        public ActionResult UserError(int id)
        {
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }
        // GET: UserViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // GET: UserViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Quantity")] UserView userView)
        {
            if (ModelState.IsValid)
            {
                service.AddUser(userView.ToUserDM());
                return RedirectToAction("Index");
            }

            return View(userView);
        }

        // GET: UserViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // POST: UserViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Quantity,Books")] UserView userView)
        {
            if (ModelState.IsValid)
            {
                service.UpdateUser(userView.ToUserDM());
                return RedirectToAction("Index");
            }
            return View(userView);
        }

        // GET: UserViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        // POST: UserViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteUser(service.GetUser(Convert.ToInt32(id)));
            return RedirectToAction("Index");
        }

        public ActionResult AddBook(int? id)
        {          
            ViewBag.Books = serviceBooks.GetBooks().ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook([Bind(Include = "UserID,FirstName,LastName,Quantity")] UserView userView)
        {
            int flag = service.AddBookToUser(userView.ToUserDM(), serviceBooks.GetBook(userView.Quantity));
            if(flag == 0)
                return RedirectToAction("Index");
            else if (flag == 1)
                return RedirectToAction("BookError", new { id = userView.Quantity });
            else
                return RedirectToAction("UserError", new { id = userView.UserID });
        }

        public ActionResult DeleteBook(int? id)
        {
            ViewBag.Books = service.GetUser(Convert.ToInt32(id)).Books.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserView userView = new UserView(service.GetUser(Convert.ToInt32(id)));
            if (userView == null)
            {
                return HttpNotFound();
            }
            return View(userView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook([Bind(Include = "UserID,FirstName,LastName,Quantity")] UserView userView)
        {
            service.DeleteBookFromUser(userView.ToUserDM(), serviceBooks.GetBook(userView.Quantity));
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
