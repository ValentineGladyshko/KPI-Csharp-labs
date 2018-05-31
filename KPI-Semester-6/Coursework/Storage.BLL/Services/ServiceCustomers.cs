using System;
using System.Collections.Generic;
using System.Linq;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceCustomers
    {
        private UnitOfWork UOW;

        public ServiceCustomers()
        {
            UOW = new UnitOfWork();
        }

        public void AddCustomer(CustomerDM customerDM)
        {
            UOW.Customers.Create(customerDM.ToCustomerNoID());

            UOW.Save();
        }

        public void DeleteCustomer(CustomerDM customerDM)
        {
            try
            {
                Customer customer = UOW.Customers.Get(customerDM.CustomerID);

                foreach (Sale s in UOW.Sales
                    .Find(s => s.CustomerID == customer.CustomerID))
                {
                    UOW.Supplies.Delete(s.SaleID);
                }
                UOW.Save();

                UOW.Customers.Delete(customer.CustomerID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Customer");
            }
        }

        public void UpdateCustomer(CustomerDM customerDM)
        {
            try
            {
                UOW.Customers.Update(customerDM.ToCustomer());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Customer");
            }
        }

        public CustomerDM GetCustomer(int ID)
        {
            try
            {
                return new CustomerDM(UOW.Customers.Get(ID), 
                    UOW.Sales.Find(s => s.CustomerID == ID)); 
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Customer");
            }
        }

        public IEnumerable<CustomerDM> GetCustomers()
        {
            List<CustomerDM> result = new List<CustomerDM>();

            foreach (Customer c in UOW.Customers.GetAll())
            {
                result.Add(new CustomerDM(c,
                    UOW.Sales.Find(s => s.CustomerID == c.CustomerID)));
            }

            return result;
        }
        public IEnumerable<CustomerDM> Sort(IEnumerable<CustomerDM> customers, int sort, bool order)
        {
            if (sort == 1)
            {
                if (order)
                    return customers.OrderBy(c => c.FirstName);
                else
                    return customers.OrderByDescending(c => c.FirstName);
            }
            else if (sort == 2)
            {
                if (order)
                    return customers.OrderBy(c => c.LastName);
                else
                    return customers.OrderByDescending(c => c.LastName);
            }
            else
                return customers;
        }

        public IEnumerable<CustomerDM> CustomerSearch(string searchString)
        {
            searchString = searchString.ToLower();

            return GetCustomers().Where(c => c.FirstName.ToLower()
                .Contains(searchString) || c.LastName.ToLower().Contains(searchString));
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
