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
    public class ServiceSales
    {
        private UnitOfWork UOW;

        public ServiceSales()
        {
            UOW = new UnitOfWork();
        }

        public bool AddSale(SaleDM saleDM)
        {
            if (saleDM.Product.Quantity < saleDM.Quantity)
            {
                return false;
            }
            else
            {
                saleDM.Product.Quantity -= saleDM.Quantity;

                UOW.Products.Update(saleDM.Product.ToProduct());
                UOW.Sales.Create(saleDM.ToSaleNoID());

                UOW.Save();
                return true;
            }
        }

        public void DeleteSale(SaleDM saleDM)
        {
            try
            {
                saleDM.Product.Quantity += saleDM.Quantity;

                UOW.Products.Update(saleDM.Product.ToProduct());
                UOW.Sales.Delete(saleDM.SaleID);

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Sale");
            }
        }

        public void UpdateSale(SaleDM saleDM)
        {
            try
            {
                UOW.Sales.Update(saleDM.ToSale());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Sale");
            }
        }

        public SaleDM GetSale(int ID)
        {
            try
            {
                return new SaleDM(UOW.Sales.Get(ID));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Sale");
            }
        }

        public IEnumerable<SaleDM> GetSales()
        {
            List<SaleDM> result = new List<SaleDM>();

            foreach (Sale s in UOW.Sales.GetAll())
            {
                result.Add(new SaleDM(s));
            }

            return result;
        }

        public IEnumerable<SaleProduct> GetSaleProducts()
        {
            return SaleProduct.GetSales(GetSales());
        }

        public IEnumerable<SaleCustomer> GetSaleCustomers()
        {
            return SaleCustomer.GetSales(GetSales());
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
