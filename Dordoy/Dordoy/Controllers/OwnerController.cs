using AutoMapper;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dordoy.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase {
        private readonly OwnerService ownerService;
        private readonly IMapper mapper;
        public OwnerController(OwnerService ownerService, IMapper mapper) {
            this.ownerService = ownerService;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Owner> GetAll() {
            return ownerService.Get();
        }

        [HttpGet("GetByID")]
        public Owner GetByID(int id) {
            return ownerService.GetByID(id);
        }

        [HttpPost("Create")]
        public void Create([FromBody] User value) {
            ownerService.Create(mapper.Map<Owner>(value));
        }

        [HttpPut("Update")]
        public void Update(int id, [FromBody] User value) {
            var res = mapper.Map<Owner>(value);
            res.Id = id;
            ownerService.Update(res);
        }

        [HttpDelete("Delete")]
        public void Delete(int id) {
            ownerService.Delete(id);
        }
    }
}
