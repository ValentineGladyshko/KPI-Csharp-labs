using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class SupplyRepository : IRepository<Supply>
    {
        private StorageContext db;

        public SupplyRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Supply> GetAll()
        {
            return db.Supplies.Include(b => b.Product)
                .Include(b => b.Provider);
        }

        public Supply Get(int id)
        {
            return db.Supplies.Find(id);
        }

        public IEnumerable<Supply> Find(Func<Supply, bool> predicate)
        {
            return db.Supplies.Include(b => b.Product)
                .Include(b => b.Provider).Where(predicate).ToList();
        }

        public void Create(Supply supply)
        {
            db.Supplies.Add(supply);
        }

        public void Update(Supply supply)
        {
            db.Entry(supply).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Supply supply = db.Supplies.Find(id);
            if (supply != null)
                db.Supplies.Remove(supply);
        }
    }
}
