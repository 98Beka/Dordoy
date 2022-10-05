using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class SaleRepository {
        private readonly ApplicationContext _db;
        public SaleRepository(ApplicationContext context) {
            _db = context;
        }

        public IQueryable<Sale> Get() {
            return _db.Sales;
        }

        public Sale GetByID(int id) {
            return _db.Sales.Include(e => e.Employee)
                .Include(e => e.Product)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Create(Sale Sale) {
            _db.Sales.Add(Sale);
        }

        public void Update(Sale Sale) {
            _db.Entry(Sale).State = EntityState.Modified;
        }

        public IEnumerable<Sale> Find(Func<Sale, Boolean> predicate) {
            return _db.Sales.Where(predicate).ToList();
        }

        public void Delete(int id) {
            Sale Sale = _db.Sales.Find(id);
            if (Sale != null)
                _db.Sales.Remove(Sale);
        }
    }
}
