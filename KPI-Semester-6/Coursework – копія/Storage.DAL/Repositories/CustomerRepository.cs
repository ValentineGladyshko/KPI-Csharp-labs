using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Storage.DAL.Interfaces;
using Storage.DAL.Entities;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private StorageContext db;

        public CustomerRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }
    }
}
