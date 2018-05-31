using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
