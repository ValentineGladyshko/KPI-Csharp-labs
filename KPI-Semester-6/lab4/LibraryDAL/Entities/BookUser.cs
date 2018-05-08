using System.ComponentModel.DataAnnotations;

namespace Library.DAL
{
    public class BookUser
    {
        [Key]
        public int BookUserID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
