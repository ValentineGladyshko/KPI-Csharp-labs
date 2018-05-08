using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<BookUser> BookUsers { get; set; }
    }
}
