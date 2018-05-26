using System;
using System.ComponentModel.DataAnnotations;

namespace Storage.DAL.Entities
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
