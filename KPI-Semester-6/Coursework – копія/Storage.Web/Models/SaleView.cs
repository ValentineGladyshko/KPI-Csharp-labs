using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class SaleView
    {
        [Key]
        public int SaleID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [RegularExpression(@"^([0]?[1-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$",
         ErrorMessage = "Invalid Date")]
        public string SaleDate { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }

        public SaleView() { }

        public SaleView(SaleDM sale)
        {
            SaleID = sale.SaleID;
            Quantity = sale.Quantity;
            SaleDate = sale.SaleDate.ToString("dd-MM-yyyy");

            Product = new Product(sale.Product);
            Customer = new Customer(sale.Customer);
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
