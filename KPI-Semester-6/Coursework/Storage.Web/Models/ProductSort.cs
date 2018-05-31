using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Web.Models
{
    public class ProductSort
    {
        public string SearchString { get; set; }
        public int Sort { get; set; }
        public bool NameOrder { get; set; }
        public bool BrandOrder { get; set; }
        public bool PriceOrder { get; set; }

        public ProductSort()
        {
            SearchString = "";
            Sort = -1;
            NameOrder = true;
            BrandOrder = true;
            PriceOrder = true;
        }

        public void ChangeOrder()
        {
            if (Sort == 1)
            {
                NameOrder = !NameOrder;
            }
            else if (Sort == 2)
            {
                BrandOrder = !BrandOrder;
            }
            else if (Sort == 3)
            {
                PriceOrder = !PriceOrder;
            }
        }

        public void CheckSort()
        {
            if (Sort == -1)
                Sort = 0;
        }

        public bool GetOrder()
        {
            if (Sort == 1)
            {
                return NameOrder;
            }
            else if (Sort == 2)
            {
                return BrandOrder;
            }
            else if (Sort == 3)
            {
                return PriceOrder;
            }
            return true;
        }

        public ProductSort GetSort(int sort)
        {
            Sort = sort;
            CheckSort();
            ChangeOrder();
            return this;
        }
    }

}