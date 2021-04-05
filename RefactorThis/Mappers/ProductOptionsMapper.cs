using AutoMapper;
using RefactorThis.Models;
using RefactorThis.Models.Entities;

namespace RefactorThis.Mappers
{
    public class ProductOptionsMapper : Profile
    {
        public ProductOptionsMapper()
        {
            CreateMap<ProductOptionsDto, ProductOptions>()
                .ReverseMap();
        }
    }
}
