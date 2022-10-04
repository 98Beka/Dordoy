using AutoMapper;
using BLL.Services;
using DAL.Models;
using Dordoy.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dordoy.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase {
        private readonly SaleService saleService;
        private readonly IMapper mapper;
        public SaleController(SaleService saleService, IMapper mapper) {
            this.saleService = saleService;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IEnumerable<Sale> GetAll() {
            return saleService.Get();
        }

        [HttpGet("GetByID")]
        public Sale GetByID(int id) {
            return saleService.GetByID(id);
        }

        [HttpPost("Create")]
        public void Create([FromBody] SaleView value) {
            saleService.Create(mapper.Map<Sale>(value));
        }

        [HttpPut("Update")]
        public void Update(int id, [FromBody] SaleView value) {
            var res = mapper.Map<Sale>(value);
            res.Id = id;
            saleService.Update(res);
        }

        [HttpDelete("Delete")]
        public void Delete(int id) {
        }
    }
}
