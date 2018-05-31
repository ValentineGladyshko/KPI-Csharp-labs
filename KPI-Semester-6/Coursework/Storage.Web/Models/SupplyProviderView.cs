using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.BusinessModels;

namespace Storage.Web.Models
{
    public class SupplyProviderView
    {
        [Key]
        public int ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SupplyProviderView() { }
        public SupplyProviderView(SupplyProvider supply)
        {
            ProviderID = supply.ProviderID;
            FirstName = supply.FirstName;
            LastName = supply.LastName;
            Quantity = supply.Quantity;
            Price = supply.Price;
        }
    }
}
