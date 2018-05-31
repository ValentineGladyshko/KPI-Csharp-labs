using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceProducts
    {
        private UnitOfWork UOW;

        public ServiceProducts()
        {
            UOW = new UnitOfWork();
        }

        public void AddProduct(ProductDM productDM)
        {
            UOW.Products.Create(productDM.ToProductNoID());

            UOW.Save();
        }

        public void DeleteProduct(ProductDM productDM)
        {
            try
            {
                Product product = UOW.Products.Get(productDM.ProductID);

                foreach (Supply s in UOW.Supplies
                    .Find(s => s.ProductID == product.ProductID))
                {
                    UOW.Supplies.Delete(s.SupplyID);
                }

                foreach (Sale s in UOW.Sales
                    .Find(s => s.ProductID == product.ProductID))
                {
                    UOW.Supplies.Delete(s.SaleID);
                }

                UOW.Save();

                UOW.Products.Delete(product.ProductID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Product");
            }
        }

        public void UpdateProduct(ProductDM productDM)
        {
            try
            {
                UOW.Products.Update(productDM.ToProduct());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Product");
            }
        }

        public ProductDM GetProduct(int ID)
        {
            try
            {
                return new ProductDM(UOW.Products.Get(ID));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Product");
            }
        }

        public IEnumerable<ProductDM> GetProducts()
        {
            List<ProductDM> result = new List<ProductDM>();

            foreach (Product p in UOW.Products.GetAll())
            {
                result.Add(new ProductDM(p));
            }

            return result;
        }

        public IEnumerable<ProductDM> Sort(IEnumerable<ProductDM> products, int sort, bool order)
        {
            if (sort == 1)
            {
                if (order)
                    return products.OrderBy(p => p.Name);
                else
                    return products.OrderByDescending(p => p.Name);
            }
            else if (sort == 2)
            {
                if (order)
                    return products.OrderBy(p => p.Brand);
                else
                    return products.OrderByDescending(p => p.Brand);
            }
            else if (sort == 3)
            {
                if (order)
                    return products.OrderBy(p => p.Price);
                else
                    return products.OrderByDescending(p => p.Price);
            }
            
            else
                return products;
        }

        public IEnumerable<ProductDM> ProductSearch(string searchString)
        {
            searchString = searchString.ToLower();

            return GetProducts().Where(p => p.Name.ToLower()
                .Contains(searchString) || p.Brand.ToLower().Contains(searchString) 
                || p.Category.Name.ToLower().Contains(searchString));
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
