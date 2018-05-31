using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Web.Models
{
    public class PersonSort
    {
        public string SearchString { get; set; }
        public int Sort { get; set; }
        public bool FirstNameOrder { get; set; }
        public bool LastNameOrder { get; set; }

        public PersonSort()
        {
            SearchString = "";
            Sort = -1;
            FirstNameOrder = true;
            LastNameOrder = true;
        }

        public void ChangeOrder()
        {
            if (Sort == 1)
            {
                FirstNameOrder = !FirstNameOrder;
            }
            else if (Sort == 2)
            {
                LastNameOrder = !LastNameOrder;
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
                return FirstNameOrder;
            }
            else if (Sort == 2)
            {
                return LastNameOrder;
            }
            return true;
        }

        public PersonSort GetSort(int sort)
        {
            Sort = sort;
            CheckSort();
            ChangeOrder();
            return this;
        }
    }
}