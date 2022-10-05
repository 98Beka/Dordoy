using AutoMapper;
using DAL;
using DAL.Models;
using DAL.Repositories;
using Dordoy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dordoy.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;
        public CategoryController(IMapper mapper, UnitOfWork unitOfWork) {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Category> GetAll() {
            return unitOfWork.CategoryRepository.Get();
            unitOfWork.Save();
        }

        [HttpGet("GetByID")]
        public Category GetByID(int id) {
            return unitOfWork.CategoryRepository.GetByID(id);
            unitOfWork.Save();
        }

        [HttpPost("Create")]
        public void Create([FromBody] CategoryView value) {
            unitOfWork.CategoryRepository.Insert(mapper.Map<Category>(value));
            unitOfWork.Save();
        }

        [HttpPut("Update")]
        public void Update(int id, [FromBody] CategoryView value) {
            var res = mapper.Map<Category>(value);
            res.Id = id;
            unitOfWork.CategoryRepository.Update(res);
            unitOfWork.Save();
        }

        [HttpDelete("Delete")]
        public void Delete(int id) {
            unitOfWork.CategoryRepository.Delete(id);
            unitOfWork.Save();
        }
    }
}
