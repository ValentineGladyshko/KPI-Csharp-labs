using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.BLL.DataModels
{
    public class UserDM
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<BookDM> Books { get; set; }
    }
}
