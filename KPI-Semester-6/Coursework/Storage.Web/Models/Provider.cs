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
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
      
        public string FullName { get => FirstName + " " + LastName; }

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
