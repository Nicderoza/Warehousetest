using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Warehouse.Common.DTOs;
using AutoMapper;
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