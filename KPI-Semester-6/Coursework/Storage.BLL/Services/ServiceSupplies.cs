using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.BusinessModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceSupplies
    {
        private UnitOfWork UOW;

        public ServiceSupplies()
        {
            UOW = new UnitOfWork();
        }

        public void AddSupply(SupplyDM supplyDM)
        {
            supplyDM.Product.Quantity += supplyDM.Quantity;

            UOW.Products.Update(supplyDM.Product.ToProduct());
            UOW.Supplies.Create(supplyDM.ToSupplyNoID());

            UOW.Save();
        }

        public bool DeleteSupply(SupplyDM supplyDM)
        {
            try
            {
                if(supplyDM.Product.Quantity < supplyDM.Quantity)
            {
                    return false;
                }
                else
                {
                    supplyDM.Product.Quantity -= supplyDM.Quantity;

                    UOW.Products.Update(supplyDM.Product.ToProduct());
                    UOW.Supplies.Delete(supplyDM.SupplyID);

                    UOW.Save();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Supply");
            }
        }

        public void UpdateSupply(SupplyDM supplyDM)
        {
            try
            {
                UOW.Supplies.Update(supplyDM.ToSupply());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Supply");
            }
        }

        public SupplyDM GetSupply(int ID)
        {
            try
            {
                return new SupplyDM(UOW.Supplies.Get(ID));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Supply");
            }
        }

        public IEnumerable<SupplyDM> GetSupplies()
        {
            List<SupplyDM> result = new List<SupplyDM>();

            foreach (Supply s in UOW.Supplies.GetAll())
            {
                result.Add(new SupplyDM(s));
            }

            return result;
        }

        public IEnumerable<SupplyProduct> GetSupplyProducts()
        {
            return SupplyProduct.GetSupplies(GetSupplies());
        }

        public IEnumerable<SupplyProvider> GetSupplyProviders()
        {
            return SupplyProvider.GetSupplies(GetSupplies());
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
