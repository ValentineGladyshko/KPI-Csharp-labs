using System.ComponentModel.DataAnnotations;
using Library.BLL.DataModels;

namespace Library.Web.Models
{
    public class AuthorFullName
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        public string Name { get; set; }

        public AuthorFullName() { }

        public AuthorFullName(AuthorDM author)
        {
            AuthorID = author.AuthorID;
            Name = author.FirstName + " " + author.LastName;
        }
    }
}