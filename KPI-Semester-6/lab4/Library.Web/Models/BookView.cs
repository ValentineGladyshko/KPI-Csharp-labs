using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.BLL.DataModels;

namespace Library.Web.Models
{
    public class BookView
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)\?!]+$",
         ErrorMessage = "Invalid Book Name.")]
        public string Name { get; set; }
        [Required]
        public int GenreID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public GenreView Genre { get; set; }

        public IEnumerable<AuthorView> Authors { get; set; }

        public BookView()
        { }

        public BookView(BookDM book)
        {
            BookID = book.BookID;
            Name = book.Name;
            GenreID = book.GenreID;
            PublishDate = book.PublishDate;
            Quantity = book.Quantity;
            List<AuthorView> MyAuthors = new List<AuthorView>();
            if (book.Authors != null)
            {
                foreach (var a in book.Authors)
                {
                    MyAuthors.Add(new AuthorView(a));
                }
            }
            Authors = MyAuthors;
        }

        public BookDM ToBookDM()
        {
            List<AuthorDM> AuthorsDM = new List<AuthorDM>();
            if (Authors != null)
            {
                foreach (var a in Authors)
                {
                    AuthorsDM.Add(a.ToAuthorDM());
                }
            }
            return new BookDM
            {
                BookID = BookID,
                Name = Name,
                GenreID = GenreID,
                PublishDate = PublishDate,
                Quantity = Quantity,
                Authors = AuthorsDM
        };
        }
    }
}