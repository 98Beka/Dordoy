using AutoMapper;
using DAL.Models;
using Dordoy.ViewModels;

namespace Dordoy.Profiles {
    public class MapperConfig : Profile {
        public MapperConfig() {

            CreateMap<ProductView, Product>();
            CreateMap<User, Owner>();
            CreateMap<WarehouseView, Warehouse>();
            CreateMap<SaleView, Sale>();
        }
    }
}
