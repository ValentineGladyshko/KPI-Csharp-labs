using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class SaleDM
    {
        public int SaleID { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }

        public ProductDM Product { get; set; }
        public CustomerDM Customer { get; set; }

        public SaleDM() { }

        public SaleDM(Sale sale)
        {
            SaleID = sale.SaleID;
            Quantity = sale.Quantity;
            SaleDate = sale.SaleDate;

            Product = new ProductDM(sale.Product);
            Customer = new CustomerDM(sale.Customer);
        }

        public Sale ToSale()
        {
            return new Sale
            {
                SaleID = SaleID,
                ProductID = Product.ProductID,
                CustomerID = Customer.CustomerID,
                Quantity = Quantity,
                SaleDate = SaleDate
            };
        }

        public Sale ToSaleNoID()
        {
            return new Sale
            {
                ProductID = Product.ProductID,
                CustomerID = Customer.CustomerID,
                Quantity = Quantity,
                SaleDate = SaleDate
            };
        }
    }
}
