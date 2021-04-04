using AutoMapper;
using RefactorThis.Models;
using RefactorThis.Models.DTO;

namespace RefactorThis.Mappers
{
    public class ProductOptionsMapper : Profile
    {
        public ProductOptionsMapper()
        {
            CreateMap<ProductOptions, ProductOptionsDto>()
                .ReverseMap();
        }
    }
}
