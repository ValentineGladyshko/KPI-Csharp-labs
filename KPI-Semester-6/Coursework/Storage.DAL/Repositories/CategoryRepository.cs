using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private StorageContext db;

        public CategoryRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
    }
}
