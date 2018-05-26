using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class AuthorView
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid Last Name.")]
        public string LastName { get; set; }

        public AuthorView()
        { }

        public AuthorView(AuthorDM author)
        {
            AuthorID = author.AuthorID;
            FirstName = author.FirstName;
            LastName = author.LastName;
        }

        public AuthorDM ToAuthorDM()
        {
            return new AuthorDM
            {
                AuthorID = AuthorID,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}