using BLL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {
    public class SaleService {
        private readonly UnitOfWork _database;

        public SaleService(string connectionString) {
            _database = new UnitOfWork(connectionString);
        }

        public void Create(Sale value) {
            _database.SaleRepository.Insert(value);
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
