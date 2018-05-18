using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class BookAuthor
    {
        [Key]
        public int BookAuthorID { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
