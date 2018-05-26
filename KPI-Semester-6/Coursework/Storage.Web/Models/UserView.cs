using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class UserView
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid Last Name.")]
        public string LastName { get; set; }
        [Required]
        public int Quantity { get; set; }

        public IEnumerable<BookView> Books { get; set; }

        public UserView()
        { }

        public UserView(UserDM user)
        {
            UserID = user.UserID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Quantity = user.Quantity;
            List<BookView> MyBooks = new List<BookView>();
            if (user.Books != null)
            {
                foreach (var b in user.Books)
                {
                    MyBooks.Add(new BookView(b));
                }
            }
            Books = MyBooks;
        }

        public UserDM ToUserDM()
        {
            List<BookDM> BooksDM = new List<BookDM>();
            if (Books != null)
            {
                foreach (var b in Books)
                {
                    BooksDM.Add(b.ToBookDM());
                }
            }
            return new UserDM
            {
                UserID = UserID,
                FirstName = FirstName,
                LastName = LastName,
                Quantity = Quantity,
                Books = BooksDM
        };
        }
    }
}