using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)\?!]+$",
         ErrorMessage = "Invalid Category Name.")]
        public string Name { get; set; }

        public Category() { }

        public Category(CategoryDM category)
        {
            CategoryID = category.CategoryID;
            Name = category.Name;
        }

        public CategoryDM ToCategory()
        {
            return new CategoryDM
            {
                CategoryID = CategoryID,
                Name = Name
            };
        }
    }
}
