using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private LibraryContext db;

        public AuthorRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }
    }
}
