using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Storage.Web.Models
{
    public class StorageWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StorageWebContext() : base("name=StorageWebContext")
        {
        }

        public System.Data.Entity.DbSet<Storage.Web.Models.ProductView> ProductViews { get; set; }

        public System.Data.Entity.DbSet<Storage.Web.Models.CustomerView> CustomerViews { get; set; }

        public System.Data.Entity.DbSet<Storage.Web.Models.CategoryView> CategoryViews { get; set; }

        public System.Data.Entity.DbSet<Storage.Web.Models.ProviderView> ProviderViews { get; set; }
        public System.Data.Entity.DbSet<Storage.Web.Models.SaleView> SaleViews { get; set; }
        public System.Data.Entity.DbSet<Storage.Web.Models.SupplyView> SupplyViews { get; set; }
    }
}
