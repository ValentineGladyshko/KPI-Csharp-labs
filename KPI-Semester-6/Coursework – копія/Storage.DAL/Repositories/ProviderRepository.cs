using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class ProviderRepository : IRepository<Provider>
    {
        private StorageContext db;

        public ProviderRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Provider> GetAll()
        {
            return db.Providers;
        }

        public Provider Get(int id)
        {
            return db.Providers.Find(id);
        }

        public IEnumerable<Provider> Find(Func<Provider, bool> predicate)
        {
            return db.Providers.Where(predicate).ToList();
        }

        public void Create(Provider provider)
        {
            db.Providers.Add(provider);
        }

        public void Update(Provider provider)
        {
            db.Entry(provider).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Provider provider = db.Providers.Find(id);
            if (provider != null)
                db.Providers.Remove(provider);
        }
    }
}
