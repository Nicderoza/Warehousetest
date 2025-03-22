
using AutoMapper;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;

namespace Warehouse.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categories, DTOCategory>().ReverseMap();
            CreateMap<Cities, DTOCity>().ReverseMap();
            CreateMap<Orders, DTOOrder>().ReverseMap();
            CreateMap<Products, DTOProduct>().ReverseMap();
            CreateMap<Suppliers, DTOSupplier>().ReverseMap();
            CreateMap<Users, DTOUser>().ReverseMap();
        }
    }
}
