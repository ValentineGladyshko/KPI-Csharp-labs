using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Storage.DAL.Entities;
using System.IO;

namespace Storage.DAL.Context
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base("name=StorageContext")
        {
            Database.SetInitializer<StorageContext>(new StorageDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public class StorageDbInitializer : DropCreateDatabaseAlways<StorageContext>
        {
            protected override void Seed(StorageContext db)
            {
                string path = @"C:\Users\Kappi\Source\Repos\KPI-Csharp-labs\KPI-Semester-6\Coursework\Storage.DAL\Strings";
                string[] categories = File.ReadAllLines(path + @"\categories.txt");
                string[] firstNames = File.ReadAllLines(path + @"\firstnames.txt");
                string[] lastNames = File.ReadAllLines(path + @"\lastnames.txt");
                string[] brands = File.ReadAllLines(path + @"\brands.txt");
                string[] products = File.ReadAllLines(path + @"\products.txt");

                Random random = new Random();

                int n = random.Next(10, 20);
                for (int i = 0; i < n; i++)
                {
                    db.Providers.Add(new Provider
                    {
                        FirstName = firstNames[random.Next(0, firstNames.Length)],
                        LastName = lastNames[random.Next(0, lastNames.Length)]
                    });
                }
                db.SaveChanges();

                n = random.Next(60, 100);
                for (int i = 0; i < n; i++)
                {
                    db.Customers.Add(new Customer
                    {
                        FirstName = firstNames[random.Next(0, firstNames.Length)],
                        LastName = lastNames[random.Next(0, lastNames.Length)]
                    });
                }
                db.SaveChanges();

                for (int i = 0; i < categories.Length; i++)
                { db.Categories.Add(new Category { Name = categories[i] }); }
                db.SaveChanges();

                n = random.Next(30, 50);
                for (int i = 0; i < n; i++)
                {
                    db.Products.Add(new Product
                    {
                        Name = products[random.Next(0, products.Length)],
                        Brand = brands[random.Next(0, brands.Length)],
                        Quantity = random.Next(2, 151),
                        Price = (random.Next(10, 5000) + (random.Next(0, 100) / 100))
                    });
                }
                db.SaveChanges();

                for (int i = 0; i < db.Products.Count(); i++)
                {
                    IEnumerable<Category> AllCategories = db.Categories;
                    int categoryID = AllCategories.ElementAt(random.Next(0, AllCategories.Count())).CategoryID;
                    db.ProductCategories.Add(new ProductCategory
                    {
                        ProductID = i + 1,
                        CategoryID = categoryID,
                    });
                }
                db.SaveChanges();

                n = random.Next(50, 100);
                for (int i = 0; i < n; i++)
                {
                    IEnumerable<Provider> providers = db.Providers;
                    int providerID = providers.ElementAt(random.Next(0, providers.Count())).ProviderID;
                    IEnumerable<Product> allProducts = db.Products;
                    Product product = allProducts.ElementAt(random.Next(0, allProducts.Count()));
                    db.Supplies.Add(new Supply
                    {
                        ProductID = product.ProductID,
                        ProviderID = providerID,
                        Quantity = random.Next(20, 100),
                        Price = (product.Price * random.Next(40, 80) / 100),
                        SupplyDate = DateTime.Now.AddDays(-random.Next(1, 1000))
                    });
                }
                db.SaveChanges();

                n = random.Next(200, 300);
                for (int i = 0; i < n; i++)
                {
                    IEnumerable<Customer> customers = db.Customers;
                    int customerID = customers.ElementAt(random.Next(0, customers.Count())).CustomerID;
                    IEnumerable<Product> allProducts = db.Products;
                    Product product = allProducts.ElementAt(random.Next(0, allProducts.Count()));
                    db.Sales.Add(new Sale
                    {
                        ProductID = product.ProductID,
                        CustomerID = customerID,
                        Quantity = random.Next(1, 10),
                        SaleDate = DateTime.Now.AddDays(-random.Next(1, 1000))
                });
                }
                db.SaveChanges();
            }
        }
    }
}