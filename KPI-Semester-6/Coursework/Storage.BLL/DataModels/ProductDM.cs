﻿using System;
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
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public CategoryDM Category { get; set; }

        public ProductDM() { }

        public ProductDM(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Brand = product.Brand;
            CategoryID = product.CategoryID;
            Quantity = product.Quantity;
            Price = product.Price;

            Category = new CategoryDM(product.Category);
        }

        public Product ToProduct()
        {
            return new Product
            {
                ProductID = ProductID,
                Name = Name,
                Brand = Brand,
                CategoryID = CategoryID,
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
                CategoryID = CategoryID,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
