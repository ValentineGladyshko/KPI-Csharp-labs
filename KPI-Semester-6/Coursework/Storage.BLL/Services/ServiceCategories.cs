using System;
using System.Collections.Generic;
using System.Linq;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceCategories
    {
        private UnitOfWork UOW;

        public ServiceCategories()
        {
            UOW = new UnitOfWork();
        }

        public void AddCategory(CategoryDM categoryDM)
        {
            UOW.Categories.Create(categoryDM.ToCategoryNoID());

            UOW.Save();
        }

        public void DeleteCategory(CategoryDM categoryDM)
        {
            try
            {
                Category category = UOW.Categories.Get(categoryDM.CategoryID);

                foreach (ProductCategory pc in UOW.ProductCategories
                    .Find(pc => pc.CategoryID == category.CategoryID))
                {
                    UOW.ProductCategories.Delete(pc.ProductCategoryID);
                }
                UOW.Save();

                UOW.Categories.Delete(category.CategoryID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Category");
            }
        }

        public void UpdateCategory(CategoryDM categoryDM)
        {
            try
            {
                UOW.Categories.Update(categoryDM.ToCategory());

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Category");
            }
        }

        public CategoryDM GetCategory(int ID)
        {
            try
            {
                return new CategoryDM(UOW.Categories.Get(ID));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Genre");
            }
        }

        public IEnumerable<CategoryDM> GetCategories()
        {
            List<CategoryDM> result = new List<CategoryDM>();

            foreach (Category c in UOW.Categories.GetAll())
            {
                result.Add(new CategoryDM(c));
            }

            return result;
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
