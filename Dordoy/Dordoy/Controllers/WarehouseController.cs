using AutoMapper;
using BLL.Services;
using DAL.Models;
using Dordoy.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dordoy.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase {
        private readonly WarehouseService warehouseService;
        private readonly IMapper mapper;
        public WarehouseController(WarehouseService warehouseService, IMapper mapper) {
            this.warehouseService = warehouseService;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IEnumerable<Warehouse> GetAll() {
            return warehouseService.Get();
        }

        [HttpGet("GetByID")]
        public Warehouse GetByID(int id) {
            return warehouseService.GetByID(id);
        }

        [HttpPost("Create")]
        public void Create([FromBody] WarehouseView value) {
            warehouseService.Create(mapper.Map<Warehouse>(value));
        }

        [HttpPut("Update")]
        public void Update(int id, [FromBody] WarehouseView value) {
            var res = mapper.Map<Warehouse>(value);
            res.Id = id;
            warehouseService.Update(res);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
