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

        public bool DeleteCategory(CategoryDM categoryDM)
        {
            
                try
                {
                    Category category = UOW.Categories.Get(categoryDM.CategoryID);

                    if (UOW.Products.Find(p => p.CategoryID
                        == category.CategoryID).Count() == 0)
                    {
                        UOW.Categories.Delete(category.CategoryID);
                        UOW.Save();
                        return true;
                    }
                    return false;
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
                return new CategoryDM(UOW.Categories.Get(ID), 
                    UOW.Products.Find(p => p.CategoryID == ID));
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in getting Category");
            }
        }

        public IEnumerable<CategoryDM> GetCategories()
        {
            List<CategoryDM> result = new List<CategoryDM>();

            foreach (Category c in UOW.Categories.GetAll())
            {
                result.Add(new CategoryDM(c,
                    UOW.Products.Find(p => p.CategoryID == c.CategoryID)));
            }

            return result;
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
