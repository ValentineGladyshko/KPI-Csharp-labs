using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    public class BookAuthorRepository : IRepository<BookAuthor>
    {
        private LibraryContext db;

        public BookAuthorRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return db.BookAuthors.Include(b => b.Book)
                .Include(b => b.Author);
        }

        public BookAuthor Get(int id)
        {
            return db.BookAuthors.Find(id);
        }

        public IEnumerable<BookAuthor> Find(Func<BookAuthor, bool> predicate)
        {
            return db.BookAuthors.Include(b => b.Book)
                .Include(b => b.Author).Where(predicate).ToList();
        }

        public void Create(BookAuthor bookAuthor)
        {
            db.BookAuthors.Add(bookAuthor);
        }

        public void Update(BookAuthor bookAuthor)
        {
            db.Entry(bookAuthor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BookAuthor bookAuthor = db.BookAuthors.Find(id);
            if (bookAuthor != null)
                db.BookAuthors.Remove(bookAuthor);
        }
    }
}
