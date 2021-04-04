using System;
using System.Collections.Generic;
using AutoMapper;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductGateway _productGateway;
        private readonly IMapper _mapper;
        public ProductService(IProductGateway productGateway, IMapper mapper)
        {
            _productGateway = productGateway;
            _mapper = mapper;
        }
        public List<Product> GetProducts()
        {
            List<ProductDto> productDtoList = _productGateway.GetProducts();
            List<Product> productList = _mapper.Map<List<Product>>(productDtoList);
            return productList;
        }

        public Product GetProduct(Guid id)
        {
            ProductDto productDto = _productGateway.Get(id);
            Product product = _mapper.Map<Product>(productDto);
            return product;
        }

        public int SaveProduct(Product product)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return _productGateway.Save(productDto);
        }

        public int UpdateProduct(Product product)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return _productGateway.Update(productDto);
        }
        
        public int DeleteProduct(Guid id)
        {
            ProductDto productDto = new ProductDto()
            {
                Id = id
            };
            return _productGateway.Delete(productDto);
        }
    }
}
