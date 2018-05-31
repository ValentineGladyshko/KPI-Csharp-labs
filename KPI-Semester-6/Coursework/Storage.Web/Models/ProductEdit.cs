using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class ProductEdit
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
        public IEnumerable<Category> Categories { get; set; }

        public ProductEdit() { }

        public ProductEdit(ProductDM product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            CategoryID = product.CategoryID;
            Quantity = product.Quantity;
            Price = product.Price;
            Category = new Category(product.Category);
        }

        public ProductEdit(ProductDM product, IEnumerable<CategoryDM> categories)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            CategoryID = product.CategoryID;
            Quantity = product.Quantity;
            Price = product.Price;
            Category = new Category(product.Category);

            List<Category> productCategories = new List<Category>();
            if (categories!=null)
            {
                foreach(var c in categories)
                {
                    productCategories.Add(new Category(c));
                }
            }
            Categories = productCategories;
        }

        public ProductEdit(IEnumerable<CategoryDM> categories)
        {
            List<Category> productCategories = new List<Category>();
            if (categories!=null)
            {
                foreach(var c in categories)
                {
                    productCategories.Add(new Category(c));
                }
            }
            Categories = productCategories;
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
