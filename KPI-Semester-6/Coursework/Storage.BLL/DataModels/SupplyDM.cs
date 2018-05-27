using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Entities;

namespace Storage.BLL.DataModels
{
    public class SupplyDM
    {
        public int SupplyID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SupplyDate { get; set; }
        
        public ProductDM Product { get; set; }
        public ProviderDM Provider { get; set; }

        public SupplyDM() { }

        public SupplyDM(Supply supply)
        {
            SupplyID = supply.SupplyID;
            Quantity = supply.Quantity;
            Price = supply.Price;
            SupplyDate = supply.SupplyDate;

            Product = new ProductDM(supply.Product);
            Provider = new ProviderDM(supply.Provider);
        }

        public Supply ToSupply()
        {
            return new Supply
            {
                SupplyID = SupplyID,
                ProductID = Product.ProductID,
                ProviderID = Provider.ProviderID,
                Quantity = Quantity,
                Price = Price,
                SupplyDate = SupplyDate
            };
        }

        public Supply ToSupplyNoID()
        {
           return new Supply
            {
                ProductID = Product.ProductID,
                ProviderID = Provider.ProviderID,
                Quantity = Quantity,
                Price = Price,
                SupplyDate = SupplyDate
            };
        }
    }
}
