using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DataModels
{
    public class BookDM
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int GenreID { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<AuthorDM> Authors { get; set; }
    }
}
