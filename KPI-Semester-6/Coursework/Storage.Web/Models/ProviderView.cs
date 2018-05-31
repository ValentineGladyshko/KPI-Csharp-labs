using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class ProviderView
    {
        [Key]
        public int ProviderID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid Last Name.")]
        public string LastName { get; set; }

        public IEnumerable<SupplyView> Supplies { get; set; }

        public ProviderView() { }

        public ProviderView(ProviderDM provider)
        {
            ProviderID = provider.ProviderID;
            FirstName = provider.FirstName;
            LastName = provider.LastName;
            List<SupplyView> supplies = new List<SupplyView>();
            if (provider.Supplies != null)
            {
                foreach (SupplyDM s in provider.Supplies)
                {
                    supplies.Add(new SupplyView(s));
                }             
            }
            Supplies = supplies;
        }

        public ProviderDM ToProvider()
        {
            List<SupplyDM> supplies = new List<SupplyDM>();
            foreach(SupplyView s in Supplies)
            {
                supplies.Add(s.ToSupply());
            }
            return new ProviderDM
            {
                ProviderID = ProviderID,
                FirstName = FirstName,
                LastName = LastName,
                Supplies = supplies
            };
        }
    }
}
