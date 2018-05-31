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

                foreach (ProductCategory pc in UOW.ProductCategories
                    .Find(pc => pc.ProductID == product.ProductID))
                {
                    UOW.ProductCategories.Delete(pc.ProductCategoryID);
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
                return new ProductDM(UOW.Products.Get(ID),
                    UOW.Categories.Find(c => UOW.ProductCategories
                    .Find(pc => pc.ProductID == ID && pc.CategoryID == c.CategoryID)
                    .Count() > 0));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Product");
            }
        }

        public void AddCategoryToProduct(ProductDM productDM, CategoryDM categoryDM)
        {
            try
            {
                UOW.ProductCategories.Create(new ProductCategory
                {
                    ProductID = productDM.ProductID,
                    CategoryID = categoryDM.CategoryID
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in adding Category to Product");
            }
        }

        public void DeleteCategoryFromProduct(ProductDM productDM, CategoryDM categoryDM)
        {
            try
            {
                UOW.ProductCategories.Delete(UOW.ProductCategories
                    .Find(pc => pc.ProductID == productDM.ProductID
                    && pc.CategoryID == categoryDM.CategoryID).First().ProductCategoryID);

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Category from Product");
            }
        }

        public IEnumerable<ProductDM> GetProducts()
        {
            List<ProductDM> result = new List<ProductDM>();

            foreach (Product p in UOW.Products.GetAll())
            {
                result.Add(new ProductDM(p,
                    UOW.Categories.Find(c => UOW.ProductCategories
                    .Find(pc => pc.ProductID == p.ProductID && pc.CategoryID == c.CategoryID)
                    .Count() > 0)));
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
                .Contains(searchString) || p.Brand.ToLower().Contains(searchString));
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
