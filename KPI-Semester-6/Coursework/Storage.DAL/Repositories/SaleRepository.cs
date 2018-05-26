using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {
        private StorageContext db;

        public SaleRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return db.Sales.Include(b => b.Product)
                .Include(b => b.Customer);
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public IEnumerable<Sale> Find(Func<Sale, bool> predicate)
        {
            return db.Sales.Include(b => b.Product)
                .Include(b => b.Customer).Where(predicate).ToList();
        }

        public void Create(Sale sale)
        {
            db.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
                db.Sales.Remove(sale);
        }
    }
}
