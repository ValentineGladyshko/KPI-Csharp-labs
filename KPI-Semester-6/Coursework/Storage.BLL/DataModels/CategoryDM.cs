using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class CategoryDM
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductDM> Products { get; set; }

        public CategoryDM() { }

        public CategoryDM(Category category)
        {
            CategoryID = category.CategoryID;
            Name = category.Name;
        }

        public CategoryDM(Category category, IEnumerable<Product> products)
        {
            CategoryID = category.CategoryID;
            Name = category.Name;

            if (products != null)
            {
                List<ProductDM> categoryProducts = new List<ProductDM>();

                foreach (Product p in products)
                {
                    categoryProducts.Add(new ProductDM(p));
                }

                Products = categoryProducts;
            }
        }

        public Category ToCategory()
        {
            return new Category
            {
                CategoryID = CategoryID,
                Name = Name
            };
        }

        public Category ToCategoryNoID()
        {
            return new Category
            {
                Name = Name
            };
        }
    }
}
