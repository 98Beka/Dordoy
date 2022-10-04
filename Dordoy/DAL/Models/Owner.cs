using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Owner : User {
        public int Id { get; set; }
        public List<Warehouse> Warehouse { get; set; } = new List<Warehouse>();
    }
}
