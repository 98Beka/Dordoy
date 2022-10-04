namespace DAL.Models {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public int Ammountn { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}