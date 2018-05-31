using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class SupplyView
    {
        [Key]
        public int SupplyID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [RegularExpression(@"^([0]?[1-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$",
         ErrorMessage = "Invalid Date")]
        public string SupplyDate { get; set; }
        
        public Product Product { get; set; }
        public Provider Provider { get; set; }

        public SupplyView() { }

        public SupplyView(SupplyDM supply)
        {
            SupplyID = supply.SupplyID;
            Quantity = supply.Quantity;
            Price = supply.Price;
            SupplyDate = supply.SupplyDate.ToString("dd-MM-yyyy");

            Product = new Product(supply.Product);
            Provider = new Provider(supply.Provider);
        }

        public SupplyDM ToSupply()
        {
            return new SupplyDM
            {
                SupplyID = SupplyID,
                Product = Product.ToProduct(),
                Provider = Provider.ToProvider(),
                Quantity = Quantity,
                Price = Price,
                SupplyDate = DateTime
                    .ParseExact(SupplyDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
            };
        }
    }
}
