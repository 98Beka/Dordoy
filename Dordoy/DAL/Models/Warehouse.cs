using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Warehouse {
        public int Id { get; set; }
        public Owner? Owner { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
