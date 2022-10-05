using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository {
    public class ProductRepository {
        private readonly ApplicationContext _db;
        public ProductRepository(ApplicationContext context) {
            _db = context;
        }

        public IQueryable<Product> Get() {
            return _db.Products;
        }

        public  Product GetByID(int id) {
            return _db.Products.Include(e => e.Categories).FirstOrDefault(e => e.Id == id);
        }

        public void Create(Product Product) {
            _db.Products.Add(Product);
        }

        public void Update(Product Product) {
            _db.Entry(Product).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate) {
            return _db.Products.Where(predicate).ToList();
        }

        public void Delete(int id) {
            Product Product = _db.Products.Find(id);
            if (Product != null)
                _db.Products.Remove(Product);
        }
    }
}
