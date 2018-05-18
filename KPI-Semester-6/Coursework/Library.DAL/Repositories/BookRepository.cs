using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private LibraryContext db;

        public BookRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.Include(b => b.Genre);
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Include(b => b.Genre)
                .Where(predicate).ToList();
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }
}
