using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
