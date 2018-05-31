using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.DataModels;

namespace Storage.BLL.BusinessModels
{
    public class SaleProduct
    {
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SaleProduct() { }
        public SaleProduct(SaleDM sale)
        {
            ProductID = sale.Product.ProductID;
            Product = sale.Product.Name;
            Quantity = sale.Quantity;
            Price = sale.Quantity * sale.Product.Price;
        }
        public static IEnumerable<SaleProduct> GetSales(IEnumerable<SaleDM> sales)
        {
            List <SaleProduct> result = new List<SaleProduct>();
            result.Add(new SaleProduct
            {
                ProductID = -1,
                Product = "All Products",
                Quantity = 0,
                Price = 0
            });
            foreach(SaleDM sale in sales)
            {
                result[0].Quantity += sale.Quantity;
                result[0].Price += (sale.Quantity * sale.Product.Price);
                if (result.Any(sp => sp.ProductID == sale.Product.ProductID))
                {
                    result[result.FindIndex(sp => sp.ProductID == sale.Product.ProductID)]
                        .Quantity += sale.Quantity;
                    result[result.FindIndex(sp => sp.ProductID == sale.Product.ProductID)]
                        .Price += (sale.Quantity * sale.Product.Price);
                }
                else
                {
                    result.Add(new SaleProduct(sale));
                }
            }
            return result;
        }
    }
}
