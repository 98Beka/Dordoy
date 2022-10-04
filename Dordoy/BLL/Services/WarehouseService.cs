using BLL.Models;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {
    public class WarehouseService {
        private readonly UnitOfWork _database;

        public WarehouseService(string connectionString) {
            _database = new UnitOfWork(connectionString);
        }

        public void Create(Warehouse value) {
            _database.WarehouseRepository.Insert(value);
            _database.Save();
        }
        public IEnumerable<Warehouse> Get() {
            return _database.WarehouseRepository.Get().ToList();
        }

        public Warehouse GetByID(int id) {
            return _database.WarehouseRepository.GetByID(id);
        }

        public void Update(Warehouse value) {
            _database.WarehouseRepository.Update(value);
            _database.Save();
        }

        public void Delete(int id) {
            _database.WarehouseRepository.Delete(id);
            _database.Save();
        }

    }
}
