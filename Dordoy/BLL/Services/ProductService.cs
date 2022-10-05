using BLL.Models;
using DAL;
using DAL.Models;

namespace BLL.Services {
    public class ProductService {
        private readonly UnitOfWork _database;

        public ProductService(string connectionString) {
            _database = new UnitOfWork(connectionString);
        }

        public void Create(Product value) {
            _database.ProductRepository.Create(value);
            _database.Save();
        }
        public IEnumerable<Product> Get(ProductFilter filter) {
            return _database.ProductRepository.Get().ToList();
        }

        public Product GetByID(int id) {
            return _database.ProductRepository.GetByID(id);
        }

        public void Update(Product value) {
            _database.ProductRepository.Update(value);
            _database.Save();
        }

        public void Delete(int id) {
            _database.ProductRepository.Delete(id);
            _database.Save();
        }

        public void BindCategory(int productId, int categoryId) {
            var product = _database.ProductRepository.GetByID(productId);
            var category = _database.CategoryRepository.GetByID(categoryId);
            product.Categories.Add(category);
            _database.Save();
        }

        public void SeparateCategory(int productId, int categoryId) {
            var product = _database.ProductRepository.GetByID(productId);
            var category = _database.CategoryRepository.GetByID(categoryId);
            product.Categories.Remove(category);
            _database.Save();
        }
    }
}
