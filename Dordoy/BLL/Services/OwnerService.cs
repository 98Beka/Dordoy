using BLL.Models;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {
    public class OwnerService {
        private readonly UnitOfWork _database;

        public OwnerService(string connectionString) {
            _database = new UnitOfWork(connectionString);
        }

        public void Create(Owner value) {
            _database.OwnerRepository.Insert(value);
            _database.Save();
        }

        public IEnumerable<Owner> Get() {
            return _database.OwnerRepository.Get().ToList();
        }

        public Owner GetByID(int id) {
            return _database.OwnerRepository.GetByID(id);
        }

        public void Update(Owner value) {
            _database.OwnerRepository.Update(value);
            _database.Save();
        }

        public void Delete(int id) {
            _database.OwnerRepository.Delete(id);
            _database.Save();
        }
    }
}
