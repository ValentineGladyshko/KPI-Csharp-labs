using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.BusinessModels;

namespace Storage.Web.Models
{
    public class SaleCustomerView
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SaleCustomerView() { }
        public SaleCustomerView(SaleCustomer sale)
        {
            CustomerID = sale.CustomerID;
            FirstName = sale.FirstName;
            LastName = sale.LastName;
            Quantity = sale.Quantity;
            Price = sale.Price;
        }
        
    }
}
