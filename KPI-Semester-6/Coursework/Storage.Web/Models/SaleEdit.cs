using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class SaleEdit
    {
        [Key]
        public int SaleID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [RegularExpression(@"^([0]?[1-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$",
         ErrorMessage = "Invalid date format, must be dd-mm-yyyy")]
        public string SaleDate { get; set; }

        public ProductView Product { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<ProductView> Products { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public SaleEdit() { }

        public SaleEdit(SaleDM sale)
        {
            SaleID = sale.SaleID;
            Quantity = sale.Quantity;
            SaleDate = sale.SaleDate.ToString("dd-MM-yyyy");

            Product = new ProductView(sale.Product);
            Customer = new Customer(sale.Customer);
        }

        public SaleEdit(SaleDM sale, IEnumerable<ProductDM> products, IEnumerable<CustomerDM> customers)
        {
            SaleID = sale.SaleID;
            Quantity = sale.Quantity;
            SaleDate = sale.SaleDate.ToString("dd-MM-yyyy");

            Product = new ProductView(sale.Product);
            Customer = new Customer(sale.Customer);

            List<ProductView> saleProducts = new List<ProductView>();
            List<Customer> saleCustomers = new List<Customer>();
            foreach (var p in products)
            {
                saleProducts.Add(new ProductView(p));
            }
            foreach (var c in customers)
            {
                saleCustomers.Add(new Customer(c));
            }
            Products = saleProducts;
            Customers = saleCustomers;
        }

        public SaleEdit(IEnumerable<ProductDM> products, IEnumerable<CustomerDM> customers)
        {
            List<ProductView> saleProducts = new List<ProductView>();
            List<Customer> saleCustomers = new List<Customer>();
            foreach (var p in products)
            {
                saleProducts.Add(new ProductView(p));
            }
            foreach (var c in customers)
            {
                saleCustomers.Add(new Customer(c));
            }
            Products = saleProducts;
            Customers = saleCustomers;
        }


        public SaleDM ToSale()
        {
            return new SaleDM
            {
                SaleID = SaleID,
                Product = Product.ToProduct(),
                Customer = Customer.ToCustomer(),
                Quantity = Quantity,
                SaleDate = DateTime
                    .ParseExact(SaleDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
        };
        }
    }
}
