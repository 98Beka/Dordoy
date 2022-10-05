using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class WarehouseRepository {
        private readonly ApplicationContext _db;
        public WarehouseRepository(ApplicationContext context) {
            _db = context;
        }

        public IQueryable<Warehouse> Get() {
            return _db.Warehouses;
        }

        public Warehouse GetByID(int id) {
            return _db.Warehouses.Include(e => e.Products)
                .Include(e => e.Employees)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Create(Warehouse Warehouse) {
            _db.Warehouses.Add(Warehouse);
        }

        public void Update(Warehouse Warehouse) {
            _db.Entry(Warehouse).State = EntityState.Modified;
        }

        public IEnumerable<Warehouse> Find(Func<Warehouse, Boolean> predicate) {
            return _db.Warehouses.Where(predicate).ToList();
        }

        public void Delete(int id) {
            Warehouse Warehouse = _db.Warehouses.Find(id);
            if (Warehouse != null)
                _db.Warehouses.Remove(Warehouse);
        }
    }
}
