using BLL.Models;
using DAL;
using DAL.Models;

namespace BLL.Services {
    public class SaleService {
        private readonly UnitOfWork _database;

        public SaleService(string connectionString) {
            _database = new UnitOfWork(connectionString);
        }

        public void Create(Sale value) {
            _database.SaleRepository.Create(value);
            _database.Save();
        }
        public IEnumerable<Sale> Get() {
            return _database.SaleRepository.Get().ToList();
        }

        public Sale GetByID(int id) {
            return _database.SaleRepository.GetByID(id);
        }

        public void Update(Sale value) {
            _database.SaleRepository.Update(value);
            _database.Save();
        }

        public void Delete(int id) {
            _database.SaleRepository.Delete(id);
            _database.Save();
        }
    }
}
