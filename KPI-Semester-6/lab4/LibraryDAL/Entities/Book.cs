using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookUser> BookUsers { get; set; }
    }
}
