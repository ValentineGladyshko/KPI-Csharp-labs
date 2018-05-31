using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
