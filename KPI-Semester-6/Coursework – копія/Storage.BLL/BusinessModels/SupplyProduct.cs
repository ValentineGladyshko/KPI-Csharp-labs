using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.DataModels;

namespace Storage.BLL.BusinessModels
{
    public class SupplyProduct
    {
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SupplyProduct() { }
        public SupplyProduct(SupplyDM supply)
        {
            ProductID = supply.Product.ProductID;
            Product = supply.Product.Name;
            Quantity = supply.Quantity;
            Price = supply.Quantity * supply.Price;
        }
        public static IEnumerable<SupplyProduct> GetSupplies(IEnumerable<SupplyDM> supplies)
        {
            List <SupplyProduct> result = new List<SupplyProduct>();
            result.Add(new SupplyProduct
            {
                ProductID = -1,
                Product = "All Products",
                Quantity = 0,
                Price = 0
            });
            foreach(SupplyDM supply in supplies)
            {
                result[0].Quantity += supply.Quantity;
                result[0].Price += (supply.Quantity * supply.Price);
                if (result.Any(sp => sp.ProductID == supply.Product.ProductID))
                {
                    result[result.FindIndex(sp => sp.ProductID == supply.Product.ProductID)]
                        .Quantity += supply.Quantity;
                    result[result.FindIndex(sp => sp.ProductID == supply.Product.ProductID)]
                        .Price += (supply.Quantity * supply.Price);
                }
                else
                {
                    result.Add(new SupplyProduct(supply));
                }
            }
            return result;
        }
    }
}
