using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class CustomerView
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z-]{1,30}$",
         ErrorMessage = "Invalid Last Name.")]
        public string LastName { get; set; }

        public IEnumerable<SaleView> Sales { get; set; }

        public CustomerView() { }

        public CustomerView(CustomerDM customer)
        {
            CustomerID = customer.CustomerID;
            FirstName = customer.FirstName;
            LastName = customer.LastName;

            List<SaleView> sales = new List<SaleView>();
            if (customer.Sales != null)
            {
                foreach (SaleDM s in customer.Sales)
                {
                    sales.Add(new SaleView(s));
                }            
            }
            Sales = sales;
        }

        public CustomerDM ToCustomer()
        {
            List<SaleDM> sales = new List<SaleDM>();

            foreach (SaleView s in Sales)
            {
                sales.Add(s.ToSale());
            }

            return new CustomerDM
            {
                CustomerID = CustomerID,
                FirstName = FirstName,
                LastName = LastName,
                Sales = sales
            };
        }
    }
}
