using AutoMapper;
using RefactorThis.Models;

namespace RefactorThis.Mappers
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}
