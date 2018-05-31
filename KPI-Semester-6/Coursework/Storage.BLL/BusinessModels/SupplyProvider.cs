using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.BLL.DataModels;

namespace Storage.BLL.BusinessModels
{
    public class SupplyProvider
    {
        public int ProviderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public SupplyProvider() { }
        public SupplyProvider(SupplyDM supply)
        {
            ProviderID = supply.Provider.ProviderID;
            FirstName = supply.Provider.FirstName;
            LastName = supply.Provider.LastName;
            Quantity = supply.Quantity;
            Price = supply.Quantity * supply.Price;
        }
        public static IEnumerable<SupplyProvider> GetSupplies(IEnumerable<SupplyDM> supplies)
        {
            List <SupplyProvider> result = new List<SupplyProvider>();
            result.Add(new SupplyProvider
            {
                ProviderID = -1,
                FirstName = "All",
                LastName = "Providers",
                Quantity = 0,
                Price = 0
            });
            foreach (SupplyDM supply in supplies)
            {
                result[0].Quantity += supply.Quantity;
                result[0].Price += (supply.Quantity * supply.Price);
                if (result.Any(sp => sp.ProviderID == supply.Provider.ProviderID))
                {
                    result[result.FindIndex(sp => sp.ProviderID == supply.Provider.ProviderID)]
                        .Quantity += supply.Quantity;
                    result[result.FindIndex(sp => sp.ProviderID == supply.Provider.ProviderID)]
                        .Price += (supply.Quantity * supply.Price);
                }
                else
                {
                    result.Add(new SupplyProvider(supply));
                }
            }
            return result;
        }
    }
}
