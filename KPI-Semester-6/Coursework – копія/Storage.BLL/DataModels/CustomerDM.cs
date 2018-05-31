using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class CustomerDM
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<SaleDM> Sales { get; set; }

        public CustomerDM() { }

        public CustomerDM(Customer customer)
        {
            CustomerID = customer.CustomerID;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
        }

        public CustomerDM(Customer customer, IEnumerable<Sale> sales)
        {
            CustomerID = customer.CustomerID;
            FirstName = customer.FirstName;
            LastName = customer.LastName;

            if (sales != null)
            {
                List<SaleDM> customerSales = new List<SaleDM>();

                foreach (Sale s in sales)
                {
                    customerSales.Add(new SaleDM(s));
                }

                Sales = customerSales;
            }
        }

        public Customer ToCustomer()
        {
            return new Customer
            {
                CustomerID = CustomerID,
                FirstName = FirstName,
                LastName = LastName
            };
        }

        public Customer ToCustomerNoID()
        {
            return new Customer
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
