using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string FullName { get => FirstName + " " + LastName; }

        public Customer() { }

        public Customer(CustomerDM customer)
        {
            CustomerID = customer.CustomerID;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
        }

        public CustomerDM ToCustomer()
        {
            return new CustomerDM
            {
                CustomerID = CustomerID,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
