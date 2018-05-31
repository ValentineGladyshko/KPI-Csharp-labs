using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
