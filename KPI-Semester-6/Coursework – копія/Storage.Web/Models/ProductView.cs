using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class ProductView
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)\?!]+$",
         ErrorMessage = "Invalid Product Name.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)\?!]+$",
         ErrorMessage = "Invalid Brand Name.")]
        public string Brand { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        public IEnumerable<CategoryView> Categories { get; set; }

        public ProductView() { }

        public ProductView(ProductDM product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            Quantity = product.Quantity;
            Price = product.Price;
            List<CategoryView> categories = new List<CategoryView>();
            if (product.Categories != null)
            {
                foreach (var c in product.Categories)
                {
                    categories.Add(new CategoryView(c));
                }
            }
            Categories = categories;
        }

        public ProductDM ToProduct()
        {
            List<CategoryDM> categories = new List<CategoryDM>();
            if (Categories != null)
            {
                foreach (var c in Categories)
                {
                    categories.Add(c.ToCategory());
                }
            }
            return new ProductDM
            {
                ProductID = ProductID,
                Name = Name,
                Brand = Brand,
                Quantity = Quantity,
                Price = Price,
                Categories = categories
            };
        }
    }
}
