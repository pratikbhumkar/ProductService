using AutoMapper;
using RefactorThis.Models;
using RefactorThis.Models.Entities;

namespace RefactorThis.Mappers
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Products>()
                .ReverseMap();
        }
    }
}
