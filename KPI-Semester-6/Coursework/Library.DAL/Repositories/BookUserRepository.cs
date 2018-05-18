using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    public class BookUserRepository : IRepository<BookUser>
    {
        private LibraryContext db;

        public BookUserRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<BookUser> GetAll()
        {
            return db.BookUsers.Include(b => b.Book)
                .Include(b => b.User);
        }

        public BookUser Get(int id)
        {
            return db.BookUsers.Find(id);
        }

        public IEnumerable<BookUser> Find(Func<BookUser, bool> predicate)
        {
            return db.BookUsers.Include(b => b.Book)
                .Include(b => b.User).Where(predicate).ToList();
        }

        public void Create(BookUser bookUser)
        {
            db.BookUsers.Add(bookUser);
        }

        public void Update(BookUser bookUser)
        {
            db.Entry(bookUser).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BookUser bookUser = db.BookUsers.Find(id);
            if (bookUser != null)
                db.BookUsers.Remove(bookUser);
        }
    }
}
