namespace DAL.Models {
    public class Employee : User {
        public int Id { get; set; }
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}