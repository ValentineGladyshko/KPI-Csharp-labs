using System;
using System.Collections.Generic;
using System.Linq;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceProviders
    {
        private UnitOfWork UOW;

        public ServiceProviders()
        {
            UOW = new UnitOfWork();
        }

        public void AddProvider(ProviderDM providerDM)
        {
            UOW.Providers.Create(providerDM.ToProviderNoID());

            UOW.Save();
        }

        public void DeleteProvider(ProviderDM providerDM)
        {
            try
            {
                Provider provider = UOW.Providers.Get(providerDM.ProviderID);

                foreach (Supply s in UOW.Supplies
                    .Find(s => s.ProviderID == provider.ProviderID))
                {
                    UOW.Supplies.Delete(s.SupplyID);
                }
                UOW.Save();

                UOW.Providers.Delete(provider.ProviderID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Provider");
            }
        }

        public void UpdateProvider(ProviderDM providerDM)
        {
            try
            {
                UOW.Providers.Update(providerDM.ToProvider());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Provider");
            }
        }

        public ProviderDM GetProvider(int ID)
        {
            try
            {
                return new ProviderDM(UOW.Providers.Get(ID), 
                    UOW.Supplies.Find(s => s.ProviderID == ID)); 
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Provider");
            }
        }

        public IEnumerable<ProviderDM> GetProviders()
        {
            List<ProviderDM> result = new List<ProviderDM>();

            foreach (Provider p in UOW.Providers.GetAll())
            {
                result.Add(new ProviderDM(p,
                    UOW.Supplies.Find(s => s.ProviderID == p.ProviderID)));
            }

            return result;
        }

        public IEnumerable<ProviderDM> SortByFirstName(IEnumerable<ProviderDM> providers)
        {
            return providers.OrderBy(p => p.FirstName);
        }

        public IEnumerable<ProviderDM> SortByLastName(IEnumerable<ProviderDM> providers)
        {
            return providers.OrderBy(p => p.LastName);
        }

        public IEnumerable<ProviderDM> ProviderSearch(IEnumerable<ProviderDM> providers, string searchString)
        {
            searchString = searchString.ToLower();

            return providers.Where(p => p.FirstName.ToLower()
                .Contains(searchString) || p.LastName.ToLower().Contains(searchString));
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
