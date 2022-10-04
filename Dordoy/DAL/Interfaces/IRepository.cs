using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces {
    public interface IRepository<T> where T : class {
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task CreateAsync(T item);
        void Update(T item);
        void Delete(int id);
    }
}
