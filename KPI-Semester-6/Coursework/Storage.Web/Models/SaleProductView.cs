using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.BusinessModels;

namespace Storage.Web.Models
{
    public class SaleProductView
    {
        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SaleProductView() { }
        public SaleProductView(SaleProduct sale)
        {
            ProductID = sale.ProductID;
            Product = sale.Product;
            Quantity = sale.Quantity;
            Price = sale.Price;
        }
    }
}
