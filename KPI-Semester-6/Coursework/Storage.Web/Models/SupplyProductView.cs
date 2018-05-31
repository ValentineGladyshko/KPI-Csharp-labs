using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.BusinessModels;

namespace Storage.Web.Models
{
    public class SupplyProductView
    {
        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SupplyProductView() { }
        public SupplyProductView(SupplyProduct supply)
        {
            ProductID = supply.ProductID;
            Product = supply.Product;
            Quantity = supply.Quantity;
            Price = supply.Price;
        }
    }
}
