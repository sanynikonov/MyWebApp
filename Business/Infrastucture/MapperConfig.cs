using AutoMapper;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MapperBusinessProfile : Profile
    {
        public MapperBusinessProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<OrderDTO, Order>()
                .ForMember(x => x.Products, opt => opt.Ignore());
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.Products, opt => opt.Ignore());
        }
    }
}
