using System;
using Storage.DAL.Context;

namespace Storage.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private StorageContext db = new StorageContext();
        private CategoryRepository categoryRepository;
        private CustomerRepository customerRepository;
        private ProductCategoryRepository productCategoryRepository;
        private ProductRepository productRepository;
        private ProviderRepository providerRepository;
        private SaleRepository saleRepository;
        private SupplyRepository supplyRepository;

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public ProductCategoryRepository ProductCategories
        {
            get
            {
                if (productCategoryRepository == null)
                    productCategoryRepository = new ProductCategoryRepository(db);
                return productCategoryRepository;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public ProviderRepository Providers
        {
            get
            {
                if (providerRepository == null)
                    providerRepository = new ProviderRepository(db);
                return providerRepository;
            }
        }

        public SaleRepository Sales
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository(db);
                return saleRepository;
            }
        }

        public SupplyRepository Supplies
        {
            get
            {
                if (supplyRepository == null)
                    supplyRepository = new SupplyRepository(db);
                return supplyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
