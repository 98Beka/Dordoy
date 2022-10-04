using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dordoy.ViewModels {
    public class ProductView {
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public int Ammountn { get; set; }
    }
}
