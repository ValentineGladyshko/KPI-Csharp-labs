using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Library.DAL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private LibraryContext db;

        public GenreRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public IEnumerable<Genre> Find(Func<Genre, bool> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }
    }
}
