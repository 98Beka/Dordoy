using DAL.Contexts;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL {
    public class UnitOfWork : IDisposable {
        private readonly DbContextOptions<ApplicationContext> dbContextOptions;
        public delegate int SaveDelegate();
        public event SaveDelegate SaveEvent;

        private ApplicationContext context {
            get {
                var tmp = new ApplicationContext(dbContextOptions);
                SaveEvent += tmp.SaveChanges;

                return tmp;
            }
        }

        public UnitOfWork(string connectionString) {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);

            dbContextOptions = optionsBuilder.Options;
        }

        public GenericRepository<Sale> SaleRepository {
            get {
                return new GenericRepository<Sale>(context);
            }
        }


        public GenericRepository<Employee> EmployeeRepository {
            get {
                return new GenericRepository<Employee>(context);
            }
        }

        public GenericRepository<Owner> OwnerRepository {
            get {
                return new GenericRepository<Owner>(context);
            }
        }

        public GenericRepository<Product> ProductRepository {
            get {
                return new GenericRepository<Product>(context);
            }
        }

        public GenericRepository<Warehouse> WarehouseRepository {
            get {
                return new GenericRepository<Warehouse>(context);
            }
        }

        public GenericRepository<Category> CategoryRepository {
            get {
                return new GenericRepository<Category>(context);
            }
        }

        public void Save() {
            SaveEvent?.Invoke();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}