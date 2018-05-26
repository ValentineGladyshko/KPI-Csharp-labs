using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class GenreView
    {
        [Key]
        public int GenreID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z- \(\)]{1,100}$",
         ErrorMessage = "Invalid Genre Name.")]
        public string Name { get; set; }

        public GenreView()
        { }
        
        public GenreView(GenreDM genre)
        {
            GenreID = genre.GenreID;
            Name = genre.Name;
        }

        public GenreDM ToGenreDM()
        {
            return new GenreDM
            {
                GenreID = GenreID,
                Name = Name
            };
        }
    }
}