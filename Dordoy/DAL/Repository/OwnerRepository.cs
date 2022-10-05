using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class OwnerRepository {
        private readonly ApplicationContext _db;
        public OwnerRepository(ApplicationContext context) {
            _db = context;
        }

        public IQueryable<Owner> Get() {
            return _db.Owners;
        }

        public Owner GetByID(int id) {
            return _db.Owners.Include(e => e.Warehouse).FirstOrDefault(e => e.Id == id);
        }

        public void Create(Owner Owner) {
            _db.Owners.Add(Owner);
        }

        public void Update(Owner Owner) {
            _db.Entry(Owner).State = EntityState.Modified;
        }

        public IEnumerable<Owner> Find(Func<Owner, Boolean> predicate) {
            return _db.Owners.Where(predicate).ToList();
        }

        public void Delete(int id) {
            Owner Owner = _db.Owners.Find(id);
            if (Owner != null)
                _db.Owners.Remove(Owner);
        }
    }
}
