using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class ProviderDM
    {
        public int ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<SupplyDM> Supplies { get; set; }

        public ProviderDM() { }

        public ProviderDM(Provider provider)
        {
            ProviderID = provider.ProviderID;
            FirstName = provider.FirstName;
            LastName = provider.LastName;
        }

        public ProviderDM(Provider provider, IEnumerable<Supply> supplies)
        {
            ProviderID = provider.ProviderID;
            FirstName = provider.FirstName;
            LastName = provider.LastName;

            if (supplies != null)
            {
                List<SupplyDM> providerSupplies = new List<SupplyDM>();

                foreach (Supply s in supplies)
                {
                    providerSupplies.Add(new SupplyDM(s));
                }

                Supplies = providerSupplies;
            }
        }

        public Provider ToProvider()
        {
            return new Provider
            {
                ProviderID = ProviderID,
                FirstName = FirstName,
                LastName = LastName
            };
        }

        public Provider ToProviderNoID()
        {
           return new Provider
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
