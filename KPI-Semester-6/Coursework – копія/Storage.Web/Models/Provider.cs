using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class Provider
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

        public Provider() { }

        public Provider(ProviderDM provider)
        {
            ProviderID = provider.ProviderID;
            FirstName = provider.FirstName;
            LastName = provider.LastName;
        }

        public ProviderDM ToProvider()
        {          
            return new ProviderDM
            {
                ProviderID = ProviderID,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
