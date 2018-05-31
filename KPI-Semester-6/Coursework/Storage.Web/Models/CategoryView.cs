using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class CategoryView
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)\?!]+$",
         ErrorMessage = "Invalid Category Name.")]
        public string Name { get; set; }

        public IEnumerable<ProductView> Products { get; set; }

        public CategoryView() { }

        public CategoryView(CategoryDM category)
        {
            CategoryID = category.CategoryID;
            Name = category.Name;

            List<ProductView> products = new List<ProductView>();
            if (category.Products != null)
            {
                foreach (var p in category.Products)
                {
                    products.Add(new ProductView(p));
                }
            }
            Products = products;
        }

        public CategoryDM ToCategory()
        {
            List<ProductDM> products = new List<ProductDM>();

            foreach (var p in Products)
            {
                products.Add(p.ToProduct());
            }

            return new CategoryDM
            {
                CategoryID = CategoryID,
                Name = Name,
                Products = products
            };
        }
    }
}
