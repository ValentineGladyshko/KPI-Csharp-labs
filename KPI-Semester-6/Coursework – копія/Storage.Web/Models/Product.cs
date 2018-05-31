using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class Product
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

        public Product() { }

        public Product(ProductDM product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            Quantity = product.Quantity;
            Price = product.Price;
        }

        public ProductDM ToProduct()
        {
            return new ProductDM
            {
                ProductID = ProductID,
                Name = Name,
                Brand = Brand,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
