using System;
using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class Supply
    {
        [Key]
        public int SupplyID { get; set; }
        public int ProductID { get; set; }
        public int ProviderID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SupplyDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
