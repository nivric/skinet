using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>().ForMember(m =>m.ProductType, o => o.MapFrom(o => o.ProductType.Name))
            .ForMember(m => m.ProductBrand, o => o.MapFrom(o => o.ProductBrand.Name))
            .ForMember(m => m.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
