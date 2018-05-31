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
        public int CategoryID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public Category Category { get; set; }

        public ProductView() { }

        public ProductView(ProductDM product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            CategoryID = product.CategoryID;
            Quantity = product.Quantity;
            Price = product.Price;
            Category = new Category(product.Category);
        }

        public ProductDM ToProduct()
        { 
            return new ProductDM
            {
                ProductID = ProductID,
                Name = Name,
                Brand = Brand,
                CategoryID = CategoryID,
                Quantity = Quantity,
                Price = Price,
                Category = Category.ToCategory()
            };
        }
    }
}
