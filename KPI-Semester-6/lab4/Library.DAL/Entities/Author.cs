using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
