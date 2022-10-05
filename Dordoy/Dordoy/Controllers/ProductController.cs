using AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Models;
using Dordoy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dordoy.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly ProductService productService;
        private readonly IMapper mapper;

        public ProductController(ProductService productService, IMapper mapper) {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpPost("GetAll")]
        public IEnumerable<Product> GetAll(ProductFilter filter, int pageNumber = 1, int pageSize = 10) {
            return productService.Get(filter);
        }

        [HttpGet("GetByID")]
        public Product GetByID(int id) {
            return productService.GetByID(id);
        }

        [HttpPost("Create")]
        public void Create([FromBody] ProductView value) {
            productService.Create(mapper.Map<Product>(value));
        }

        [HttpPut("Update")]
        public void Update(int id, [FromBody] ProductView value) {
            var res = mapper.Map<Product>(value);
            res.Id = id;
            productService.Update(res);
        }

        [HttpDelete("Delete")]
        public void Delete(int id) {
            productService.Delete(id);
        }

        [HttpGet("BindCategory")]
        public void BindCategory(int productId, int categoryId) {
            productService.BindCategory(productId, categoryId);
        }

        [HttpGet("SeparateCategory")]
        public void SeparateCategory(int productId, int categoryId) {
            productService.SeparateCategory(productId, categoryId);
        }
    }
}
