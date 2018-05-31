using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.DataModels;

namespace Storage.BLL.BusinessModels
{
    public class SaleCustomer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SaleCustomer() { }
        public SaleCustomer(SaleDM sale)
        {
            CustomerID = sale.Customer.CustomerID;
            FirstName = sale.Customer.FirstName;
            LastName = sale.Customer.LastName;
            Quantity = sale.Quantity;
            Price = sale.Quantity * sale.Product.Price;
        }
        public static IEnumerable<SaleCustomer> GetSales(IEnumerable<SaleDM> sales)
        {
            List <SaleCustomer> result = new List<SaleCustomer>();
            result.Add(new SaleCustomer
            {
                CustomerID = -1,
                FirstName = "All Customers",
                Quantity = 0,
                Price = 0
            });
            foreach (SaleDM sale in sales)
            {
                result[0].Quantity += sale.Quantity;
                result[0].Price += (sale.Quantity * sale.Product.Price);
                if (result.Any(sp => sp.CustomerID == sale.Customer.CustomerID))
                {
                    result[result.FindIndex(sp => sp.CustomerID == sale.Customer.CustomerID)]
                        .Quantity += sale.Quantity;
                    result[result.FindIndex(sp => sp.CustomerID == sale.Customer.CustomerID)]
                        .Price += (sale.Quantity * sale.Product.Price);
                }
                else
                {
                    result.Add(new SaleCustomer(sale));
                }
            }
            return result;
        }
    }
}
