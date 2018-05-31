using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private StorageContext db;

        public ProductCategoryRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return db.ProductCategories.Include(b => b.Product)
                .Include(b => b.Category);
        }

        public ProductCategory Get(int id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> Find(Func<ProductCategory, bool> predicate)
        {
            return db.ProductCategories.Include(b => b.Product)
                .Include(b => b.Category).Where(predicate).ToList();
        }

        public void Create(ProductCategory productCategory)
        {
            db.ProductCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            db.Entry(productCategory).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory != null)
                db.ProductCategories.Remove(productCategory);
        }
    }
}
