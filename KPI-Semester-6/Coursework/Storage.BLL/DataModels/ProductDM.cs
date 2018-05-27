using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class ProductDM
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<CategoryDM> Categories { get; set; }

        public ProductDM() { }

        public ProductDM(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            Quantity = product.Quantity;
            Price = product.Price;
        }

        public ProductDM(Product product, IEnumerable<Category> categories)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            Quantity = product.Quantity;
            Price = product.Price;

            if (categories != null)
            {
                List<CategoryDM> productCategories = new List<CategoryDM>();

                foreach (Category c in categories)
                {
                    productCategories.Add(new CategoryDM(c));
                }

                Categories = productCategories;
            }
        }

        public Product ToProduct()
        {
            return new Product
            {
                ProductID = ProductID,
                Name = Name,
                Brand = Brand,
                Quantity = Quantity,
                Price = Price
            };
        }

        public Product ToProductNoID()
        {
            return new Product
            {
                Name = Name,
                Brand = Brand,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
