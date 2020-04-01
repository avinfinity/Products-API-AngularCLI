using AutoMapper;
using Product.Common;
using Product.DAL;
using Product.Domain;

namespace Product.Services
{
    internal sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductEntity, ProductDTO>().ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => new TotalPriceCalculator(src).TotalPrice));
            CreateMap<ProductDTO, ProductEntity>();
        }
    }
}