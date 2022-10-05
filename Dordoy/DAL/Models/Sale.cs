using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Sale {
        public int Id { get; set; } 
        public Product Product { get; set; }
        public Employee Employee { get; set; }
    }
}
