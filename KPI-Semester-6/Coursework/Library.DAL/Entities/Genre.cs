using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
