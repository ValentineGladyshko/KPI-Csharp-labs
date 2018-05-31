using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Storage.BLL.DataModels;

namespace Storage.Web.Models
{
    public class SupplyEdit
    {
        [Key]
        public int SupplyID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [RegularExpression(@"^([0]?[1-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$",
         ErrorMessage = "Invalid date format, must be dd-mm-yyyy")]
        public string SupplyDate { get; set; }
        
        public ProductView Product { get; set; }
        public Provider Provider { get; set; }

        public IEnumerable<ProductView> Products { get; set; }
        public IEnumerable<Provider> Providers { get; set; }

        public SupplyEdit() { }

        public SupplyEdit(SupplyDM supply)
        {
            SupplyID = supply.SupplyID;
            Quantity = supply.Quantity;
            Price = supply.Price;
            SupplyDate = supply.SupplyDate.ToString("dd-MM-yyyy");

            Product = new ProductView(supply.Product);
            Provider = new Provider(supply.Provider);
        }

        public SupplyEdit(SupplyDM supply, IEnumerable<ProductDM> products, IEnumerable<ProviderDM> providers)
        {
            SupplyID = supply.SupplyID;
            Quantity = supply.Quantity;
            Price = supply.Price;
            SupplyDate = supply.SupplyDate.ToString("dd-MM-yyyy");

            Product = new ProductView(supply.Product);
            Provider = new Provider(supply.Provider);

            List<ProductView> supplyProducts = new List<ProductView>();
            List<Provider> supplyProviders = new List<Provider>();
            foreach(var p in products)
            {
                supplyProducts.Add(new ProductView(p));
            }
            foreach (var p in providers)
            {
                supplyProviders.Add(new Provider(p));
            }
            Products = supplyProducts;
            Providers = supplyProviders;
        }

        public SupplyEdit(IEnumerable<ProductDM> products, IEnumerable<ProviderDM> providers)
        {
            List<ProductView> supplyProducts = new List<ProductView>();
            List<Provider> supplyProviders = new List<Provider>();
            foreach (var p in products)
            {
                supplyProducts.Add(new ProductView(p));
            }
            foreach (var p in providers)
            {
                supplyProviders.Add(new Provider(p));
            }
            Products = supplyProducts;
            Providers = supplyProviders;
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
